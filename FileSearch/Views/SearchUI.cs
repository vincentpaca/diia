using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EchoSystems.Common.Global;
using System.Diagnostics;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.DIIA.FileSearch.Models;
namespace EchoSystems.DIIA.FileSearch.Views
{
    public partial class SearchUI : Form
    {
        private int lSearchCount;
        private int lOffset;
        private int lPage;
        private int lImageSearchCount;
        private int lImageOffset;
        private int lImagePage;
        private EchoSystems.DIIA.FileSearch.Controller.FileSearch loFileSearch;
        public SearchUI()
        {
            InitializeComponent();
            loFileSearch = new EchoSystems.DIIA.FileSearch.Controller.FileSearch();
            lSearchCount = 0;
            lOffset = 0;
            lPage = 0;
            lImageOffset = 0;
            lImagePage = 0;
            lImageSearchCount = 0;
        }

        private void SearchUI_Load(object sender, EventArgs e)
        {
            loadNewsPapers();
            loadDocTypes();
            loadSections();
            txtDocumentSearch.Focus();
            cboDocType.SelectedIndex = cboDocType.Items.Count - 1;
            cboSection.SelectedIndex = cboSection.Items.Count - 1;
        }

        private void loadNewsPapers()
        {
            cboNewspaper.DataSource = loFileSearch.getNewsPapers();
            cboNewspaper.DisplayMember = "Name";
            cboNewspaper.ValueMember = "NewsPaperId";
        }
        private void loadDocTypes()
        {
            cboDocType.DataSource = loFileSearch.getDocTypes("search");
            cboDocType.DisplayMember = "DocType";
        }

        private void loadSections()
        {
            cboSection.DataSource = loFileSearch.getSections("search", cboNewspaper.SelectedValue.ToString());
            cboSection.DisplayMember = "Section";
            cboSection.ValueMember = "SectionId";
            cboSection.Text = "ALL";
        }

        DateTime lFrom;
        DateTime lTo;
        string lNewspaper;
        string lDoctype;
        string lSection;
        string lSearchTags;
        private void btnDocumentSearch_Click(object sender, EventArgs e)
        {
            lFrom = dtpDocumentFrom.Value;
            lTo = dtpDocumentTo.Value;
            if (!chkDocumentDateFilter.Checked)
            {
                lFrom = DateTime.Parse("1900-01-01 01:01:01");
                lTo = DateTime.Parse("1900-01-01 01:01:01");
            }

            lNewspaper = cboNewspaper.SelectedValue.ToString();
            lDoctype = cboDocType.Text;
            lSection = cboSection.SelectedValue.ToString();
            lSearchTags = GlobalFunctions.addSlashes(txtDocumentSearch.Text.ToLower());

            loadFirstPage();
        }

        private void loadFirstPage()
        {
            lPage = 1;
            lOffset = 0;

            loadgrid();

            string _diplay = "";
            if (lPage * GlobalVariables.gLimit > lSearchCount)
            {
                _diplay = lSearchCount.ToString();
                llblDocumentNext.Enabled = false;
            }
            else
            {
                _diplay = (lPage * GlobalVariables.gLimit).ToString();
                llblDocumentNext.Enabled = true;
            }
            llblDocumentPrev.Enabled = false;
            lblDocumentDisplay.Text =  _diplay + "/" + lSearchCount.ToString();
        }

        private void loadLastPage()
        {
            lPage = 1;
            lOffset = 0;

            if (lSearchCount < GlobalVariables.gLimit)
            {
                loadFirstPage();
                return;
            }

            lPage = lSearchCount / GlobalVariables.gLimit;
            if (lSearchCount % GlobalVariables.gLimit > 0)
            {
                lPage++;
            }

            lOffset = (lPage - 1) * GlobalVariables.gLimit;

            loadgrid();

            string _diplay = "";
            _diplay = lSearchCount.ToString();
            llblDocumentNext.Enabled = false;

            if (lSearchCount <= GlobalVariables.gLimit)
            {
                llblDocumentPrev.Enabled = false;
            }
            lblDocumentDisplay.Text = _diplay + "/" + lSearchCount.ToString();
        }

        private void loadNextPage()
        {
            lPage++;
            lOffset = (lPage - 1) * GlobalVariables.gLimit;

            loadgrid();

            string _diplay = "";
            _diplay = (lOffset + GlobalVariables.gLimit).ToString();

            if (lPage * GlobalVariables.gLimit > lSearchCount)
            {
                llblDocumentNext.Enabled = false;
                _diplay = lSearchCount.ToString();
            }
            lblDocumentDisplay.Text = _diplay + "/" + lSearchCount.ToString();
        }

        private void loadPrevPage()
        {
            lPage--;
            lOffset = (lPage - 1) * GlobalVariables.gLimit;

            loadgrid();

            string _display = "";
            _display = (lOffset + GlobalVariables.gLimit).ToString();

            if (lOffset == 0)
            {
                llblDocumentPrev.Enabled = false;
                _display = GlobalVariables.gLimit.ToString();
            }
            lblDocumentDisplay.Text = _display + "/" + lSearchCount.ToString();
        }

        private void loadgrid()
        {
            DataTable _results = loFileSearch.searchDocument(lNewspaper, lDoctype, lSection, lSearchTags, lFrom, lTo, GlobalVariables.gLimit, lOffset);
            lSearchCount = loFileSearch.countDocuments(lNewspaper, lDoctype, lSection, lSearchTags, lFrom, lTo);
            //foreach (Control _control in pnlDocumentSearch.Controls)
            //{
            //    pnlDocumentSearch.Controls.Remove(_control);
            //}
            pnlDocumentSearch.Controls.Clear();
            if (_results != null && _results.Rows.Count > 0)
            {
                //grdResults.Rows.Count = 1;

                //int _row = 1;
                foreach (DataRow _dRow in _results.Rows)
                {
                    DocumentSearch _dSearch = new DocumentSearch();
                    _dSearch.Size = new System.Drawing.Size(pnlDocumentSearch.Width-25, 45);
                    _dSearch.BorderStyle = BorderStyle.FixedSingle;
   
                    _dSearch.DocumentId = _dRow["DocumentId"].ToString();
                    _dSearch.Title = _dRow["Title"].ToString();
                    _dSearch.Doctype = _dRow["Doctype"].ToString();
                    _dSearch.NewsPaper = _dRow["Newspaper"].ToString();
                    DateTime _dt = new DateTime();
                    DateTime.TryParse(_dRow["PublishedDate"].ToString(), out _dt);
                    _dSearch.Preview = _dRow["Preview"].ToString();
                    _dSearch.Section = _dRow["Section"].ToString();
                    _dSearch.PublishedDate = _dt;
                    _dSearch.populate();
                    _dSearch.Click += new System.EventHandler(this.Document_Click);
                    _dSearch.DoubleClick += new System.EventHandler(this.Document_DClick);
                    switch (_dSearch.Doctype)
                    {
                        case ".txt" :
                            _dSearch.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
                            _dSearch.BackgroundImage = GlobalFunctions.resizeImage(Image.FromFile(Application.StartupPath + "\\txt.png"), new System.Drawing.Size(40, 40));
                            break;
                        case ".doc" :
                            _dSearch.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
                            _dSearch.BackgroundImage = GlobalFunctions.resizeImage(Image.FromFile(Application.StartupPath + "\\doc.png"), new System.Drawing.Size(40, 40));
                            break;
                        case ".pdf" :
                        case ".PDF" :
                        case ".Pdf" :
                            _dSearch.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
                            _dSearch.BackgroundImage = GlobalFunctions.resizeImage(Image.FromFile(Application.StartupPath + "\\pdf.png"), new System.Drawing.Size(40, 40));
                            break;
                        case ".rtf" :
                            _dSearch.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
                            _dSearch.BackgroundImage = GlobalFunctions.resizeImage(Image.FromFile(Application.StartupPath + "\\rtf.png"), new System.Drawing.Size(40, 40));
                            break;
                    }
                    _dSearch.BackgroundImageLayout = ImageLayout.None;
                    pnlDocumentSearch.Controls.Add(_dSearch);
                    //grdResults.Rows.Count++;
                    //grdResults.SetData(_row, 0, _dRow["Title"]);
                    //grdResults.SetData(_row, 1, _dRow["Section"]);
                    //grdResults.SetData(_row, 2, _dRow["PublishedDate"]);
                    //grdResults.SetData(_row, 3, _dRow["authors"]);
                    //grdResults.SetData(_row, 4, _dRow["Newspaper"]);
                    //grdResults.SetData(_row, 5, _dRow["Doctype"]);
                    //grdResults.SetData(_row, 6, _dRow["Tags"]);
                    //grdResults.SetData(_row, 7, _dRow["DocumentId"]);
                    //_row++;
                }
            }
            else
            {
                //grdResults.Rows.Count = 1;
                foreach (Control _control in pnlDocumentSearch.Controls)
                {
                    pnlDocumentSearch.Controls.Remove(_control);
                }
            }
            //grdResults.AutoSizeCols(0, 5, 3);
        }

        private void txtDocumentSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                btnDocumentSearch_Click(null, null);
            }
        }

        //private void grdResults_SelChange(object sender, EventArgs e)
        //{
        //    if (grdResults.Col > 7)
        //    {
        //        grdResults.AllowEditing = true;
        //    }
        //    else
        //    {
        //        grdResults.AllowEditing = false;
        //    }
        //}

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                //if (grdResults.Row > 0)
                //{
                //    string _docId = grdResults.GetDataDisplay(grdResults.Row, 7).ToString();
                //    string _fileType = grdResults.GetDataDisplay(grdResults.Row, 5).ToString();
                //    string _filename = _docId + _fileType;
                //    sfdSave.FileName = grdResults.GetDataDisplay(grdResults.Row, 0).ToString();
                //    sfdSave.Title = "Save Document";
                //    if (_fileType == ".doc")
                //    {
                //        sfdSave.Filter = "Word Document (*.doc)|*.doc";
                //    }
                //    else if (_fileType == ".pdf")
                //    {
                //        sfdSave.Filter = "PDF (*.pdf)|*.pdf";
                //    }
                //    else
                //    {
                //        sfdSave.Filter = "Text Document (*.txt)|*.txt";
                //    }
                //    if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //    {
                //        File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                //        MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                if (lDocumentSearchType != "")
                {

                    sfdSave.FileName = lDocumentSearchTitle;
                    sfdSave.Title = "Save Document";

                    if (lDocumentSearchType == ".doc" || lDocumentSearchType == ".txt" || lDocumentSearchType == ".rtf")
                    {
                        //sfdSave.Filter = "Document (*" + lDocumentSearchType + ")|*" + lDocumentSearchType;
                        cmnuDownloadDocument.Show(new Point(btnDownloadDocument.Left + 50, btnDownloadDocument.Top + 100));
                    }
                    else
                    {
                        sfdSave.Filter = "PDF (*.pdf)|*.pdf";
                        string _filename = lDocumentSearchId + lDocumentSearchType;
                        if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                            MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch { }
        }

        private void SearchUI_Resize(object sender, EventArgs e)
        {
            txtDocumentSearch.Focus();
        }

        //private void grdResults_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        ViewFile _vf = new ViewFile(grdResults.GetDataDisplay(grdResults.Row, 7).ToString());
        //        _vf.ShowDialog();
        //    }
        //    catch { }
        //}

        private void llblFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblDocumentPrev.Enabled = true;
            llblDocumentNext.Enabled = true;
            loadFirstPage();
        }

        private void llblLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblDocumentPrev.Enabled = true;
            llblDocumentNext.Enabled = true;
            loadLastPage();
        }

        private void llblNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblDocumentPrev.Enabled = true;
            llblDocumentNext.Enabled = true;
            loadNextPage();
        }

        private void llblPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblDocumentPrev.Enabled = true;
            llblDocumentNext.Enabled = true;
            loadPrevPage();
        }

        DateTime lImageFrom;
        DateTime lImageTo;
        string lImageSearchTags;
        private void btnImageSearch_Click(object sender, EventArgs e)
        {
            lImageFrom = dtpImageFrom.Value;
            lImageTo = dtpImageTo.Value;
            if (!chkImageDateFilter.Checked)
            {
                lImageFrom = DateTime.Parse("1900-01-01 01:01:01");
                lImageTo = DateTime.Parse("1900-01-01 01:01:01");
            }
            lImageSearchTags = GlobalFunctions.addSlashes(txtImageSearch.Text.ToLower());
            loadImageFirstPage();
        }

        private void loadImages()
        {
            DataTable _results = loFileSearch.searchImage(lImageSearchTags, lImageFrom, lImageTo, GlobalVariables.gLimit, lImageOffset);
            lImageSearchCount = loFileSearch.countImages(lImageSearchTags, lImageFrom, lImageTo);
            ImageSearch _pic;
            pnlImages.Controls.Clear();
            if (_results != null && _results.Rows.Count > 0)
            {
                foreach (DataRow _dRow in _results.Rows)
                {
                    _pic = new ImageSearch();
                    _pic.Size = new System.Drawing.Size(150, 150);
                    _pic.BorderStyle = BorderStyle.FixedSingle;
                    _pic.Click += new System.EventHandler(this.Picture_Click);
                    _pic.DoubleClick += new System.EventHandler(this.Picture_DClick);
                    string[] _image = _dRow["Path"].ToString().Split('.');
                    string _file = _dRow["ImageId"].ToString() + ".jpg";
                    try
                    {    
                        _file = _dRow["ImageId"].ToString() + "." + _image[_image.Length - 1];
                        _pic.Image = GlobalFunctions.resizeImage(Image.FromFile(GlobalVariables.goImageServer + @"\" + _file), new Size(150, 150));
                    }
                    catch
                    {
                        _pic.Image = GlobalFunctions.resizeImage(Image.FromFile(Application.StartupPath + "\\notfound.jpg"), new Size(150, 150));
                    }
                    _pic.Tag = _file;
                    _pic.Caption = _dRow["Caption"].ToString();
                    _pic.ImageId = _dRow["ImageId"].ToString();
                    pnlImages.Controls.Add(_pic);
                }
            }
        }

        private void loadImageFirstPage()
        {
            lImagePage = 1;
            lImageOffset = 0;

            loadImages();

            string _diplay = "";
            if (lImagePage * GlobalVariables.gLimit > lImageSearchCount)
            {
                _diplay = lImageSearchCount.ToString();
                llblImageNext.Enabled = false;
            }
            else
            {
                _diplay = (lImagePage * GlobalVariables.gLimit).ToString();
                llblImageNext.Enabled = true;
            }
            llblImagePrev.Enabled = false;
            lblImageDisplay.Text = _diplay + "/" + lImageSearchCount.ToString();
        }

        private void loadImageLastPage()
        {
            lImagePage = 1;
            lImageOffset = 0;

            if (lImageSearchCount < GlobalVariables.gLimit)
            {
                loadImageFirstPage();
                return;
            }

            lImagePage = lImageSearchCount / GlobalVariables.gLimit;
            if (lImageSearchCount % GlobalVariables.gLimit > 0)
            {
                lImagePage++;
            }

            lImageOffset = (lImagePage - 1) * GlobalVariables.gLimit;

            loadImages();

            string _diplay = "";
            _diplay = lImageSearchCount.ToString();
            llblImageNext.Enabled = false;

            if (lImageSearchCount <= GlobalVariables.gLimit)
            {
                llblImagePrev.Enabled = false;
            }
            lblImageDisplay.Text = _diplay + "/" + lImageSearchCount.ToString();
        }

        private void loadImageNextPage()
        {
            lImagePage++;
            lImageOffset = (lImagePage - 1) * GlobalVariables.gLimit;

            loadImages();

            string _diplay = "";
            _diplay = (lImageOffset + GlobalVariables.gLimit).ToString();

            if (lImagePage * GlobalVariables.gLimit > lImageSearchCount)
            {
                llblImageNext.Enabled = false;
                _diplay = lImageSearchCount.ToString();
            }
            lblImageDisplay.Text = _diplay + "/" + lImageSearchCount.ToString();
        }

        private void loadImagePrevPage()
        {
            lImagePage--;
            lImageOffset = (lImagePage - 1) * GlobalVariables.gLimit;

            loadImages();

            string _display = "";
            _display = (lImageOffset + GlobalVariables.gLimit).ToString();

            if (lImageOffset == 0)
            {
                llblImagePrev.Enabled = false;
                _display = GlobalVariables.gLimit.ToString();
            }
            lblImageDisplay.Text = _display + "/" + lImageSearchCount.ToString();
        }

        private void txtImageSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                btnImageSearch_Click(null, null);
            }
        }

        private void llblImageFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblImagePrev.Enabled = true;
            llblImageNext.Enabled = true;
            loadImageFirstPage();
        }

        private void llblImagePrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblImagePrev.Enabled = true;
            llblImageNext.Enabled = true;
            loadImagePrevPage();
        }

        private void llblImageNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblImagePrev.Enabled = true;
            llblImageNext.Enabled = true;
            loadImageNextPage();
        }

        private void llblImageLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llblImagePrev.Enabled = true;
            llblImageNext.Enabled = true;
            loadImageLastPage();
        }

        string lImageFileName = "";
        string loImageSearchId = "";
        private void Picture_Click(object sender, EventArgs e)
        {
            ImageSearch _image = (ImageSearch)sender;
            try
            {
                lImageFileName = _image.Tag.ToString();
                picPreview.Image = GlobalFunctions.resizeImage(_image.Image, picPreview.Size);
                txtCaption.Text = _image.Caption;
                loImageSearchId = _image.ImageId;
                removeHighlights(pnlImages);
                _image.BorderStyle = BorderStyle.Fixed3D;
            }
            catch
            {
                picPreview.Image = GlobalFunctions.resizeImage(Image.FromFile("notfound.jpg"), picPreview.Size);
            }
        }

        string lDocumentSearchId = "";
        string lDocumentSearchType = "";
        string lDocumentSearchTitle = "";
        private void Document_Click(object sender, EventArgs e)
        {
            DocumentSearch _dSearch = (DocumentSearch)sender;
            try
            {
                lDocumentSearchId = _dSearch.DocumentId;
                lDocumentSearchType = _dSearch.Doctype;
                lDocumentSearchTitle = _dSearch.Title;
                txtDocumentPreview.Text = "";
                if (_dSearch.Preview != null && _dSearch.Preview != "")
                {
                    txtDocumentPreview.Text = _dSearch.Preview;

                }
                else
                {
                    txtDocumentPreview.Text = "NO PREVIEW AVAILABLE";
                }
                removeHighlights(pnlDocumentSearch);
                _dSearch.BorderStyle = BorderStyle.Fixed3D;
            }
            catch { }
        }

        private void Picture_DClick(object sender, EventArgs e)
        {
            ImageSearch _image = (ImageSearch)sender;
            try
            {
                string _name = _image.ImageId;
                ViewImage _vi = new ViewImage(_name);
                _vi.ShowDialog();
            }
            catch
            {
            }
        }

        private void Document_DClick(object sender, EventArgs e)
        {
            DocumentSearch _doc = (DocumentSearch)sender;
            try
            {
                string _name = _doc.DocumentId;
                ViewFile _vi = new ViewFile(_name);
                _vi.ShowDialog();
            }
            catch
            {
            }
        }

        private void btnDownloadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (lImageFileName != "")
                {
                    sfdSave.FileName = lImageFileName;
                    sfdSave.Title = "Save Image";
      
                    if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Copy(@"" + GlobalVariables.goImageServer + @"\" + lImageFileName, sfdSave.FileName);
                        MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }

        //private void btnDeleteDocument_Click(object sender, EventArgs e)
        //{
        //    if (grdResults.Row > 0)
        //    {
        //        DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this document?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (_rsp == DialogResult.Yes)
        //        {
        //            if (loFileSearch.deleteDocument(grdResults.GetData(grdResults.Row, 7).ToString()))
        //            {
        //                grdResults.Rows.Remove(grdResults.Row);
        //                MessageBox.Show("Document deleted successful", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //        }
        //    }
        //}

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (loImageSearchId != "")
            {
                DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this image?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    if (loFileSearch.deleteImage(loImageSearchId))
                    {
                        btnImageSearch_Click(null, null);
                        MessageBox.Show("Image deleted successfully", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            if (lDocumentSearchId != "")
            {
                DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this document?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    if (loFileSearch.deleteDocument(lDocumentSearchId))
                    {
                        btnDocumentSearch_Click(null, null);
                        MessageBox.Show("Document deleted successfully", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void tsmText_Click(object sender, EventArgs e)
        {
            if (lDocumentSearchType == ".txt")
            {
                sfdSave.Filter = "Text Document (*.txt)|*.txt";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Text Document (*.txt)|*.txt";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                try
                {
                    if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        Converter _converter = new Converter();
                        if (_converter.convertDocToTxt(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName))
                        {
                            MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem converting the file: " + ex.Message, "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmDoc_Click(object sender, EventArgs e)
        {
            if (lDocumentSearchType == ".doc" || lDocumentSearchType == ".rtf")
            {
                sfdSave.Filter = "Word Document (*.doc)|*.doc";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Word Document (*.doc)|*.doc";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                try
                {
                    if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        Converter _converter = new Converter();
                        if (_converter.convertTxtToDoc(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName))
                        {
                            MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem converting the file: " + ex.Message, "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeHighlights(FlowLayoutPanel pPanel)
        {
            foreach (Control _control in pPanel.Controls)
            {
                if (_control is ImageSearch)
                {
                    ImageSearch _image = (ImageSearch)_control;
                    _image.BorderStyle = BorderStyle.FixedSingle;
                }
                if (_control is DocumentSearch)
                {
                    DocumentSearch _doc = (DocumentSearch)_control;
                    _doc.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void cboNewspaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSections();
            //btnDocumentSearch_Click(null, null);
        }

        private void tsmRtf_Click(object sender, EventArgs e)
        {
            if (lDocumentSearchType == ".doc" || lDocumentSearchType == ".rtf")
            {
                sfdSave.Filter = "Rich Text File (*.rtf)|*.rtf";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Word Document (*.rtf)|*.rtf";
                string _filename = lDocumentSearchId + lDocumentSearchType;
                try
                {
                    if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        Converter _converter = new Converter();
                        if (_converter.convertTxtToDoc(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName))
                        {
                            MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem converting the file: " + ex.Message, "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
