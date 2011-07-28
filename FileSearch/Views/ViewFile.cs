using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.DIIA.FileSearch.Controller;
using EchoSystems.DIIA.FileManager.Models;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using EchoSystems.Common.Global;
using System.Diagnostics;
using EchoSystems.DIIA.FileSearch.Models;
namespace EchoSystems.DIIA.FileSearch.Views
{
    public partial class ViewFile : Form
    {
        private string lDocumentId;
        private EchoSystems.DIIA.FileSearch.Controller.FileSearch loFilSearch;
        private Document loDocument;
        ComboBox cboAuthors;
        ComboBox cboEditors;
        DataTable loAuthors;
        DataTable loEditors;
        public ViewFile()
        {
            InitializeComponent();
        }
        public ViewFile(string pDocumentId)
        {
            InitializeComponent();
            lDocumentId = pDocumentId;
            loFilSearch = new EchoSystems.DIIA.FileSearch.Controller.FileSearch();
            cboAuthors = new ComboBox();
            cboAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditors = new ComboBox();
            cboEditors.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void loadNewspapers()
        {
            cboNewspaper.DataSource = loFilSearch.getNewsPapers();
            cboNewspaper.DisplayMember = "Name";
            cboNewspaper.ValueMember = "NewsPaperId";
        }

        private void loadSections()
        {
            cboSection.DataSource = loFilSearch.getSections("", cboNewspaper.SelectedValue.ToString());
            cboSection.DisplayMember = "Section";
            cboSection.ValueMember = "SectionId";
        }

        private void ViewFile_Load(object sender, EventArgs e)
        {
            loDocument = loFilSearch.getDocument(lDocumentId);
            loadNewspapers();
           
            loadSections();
            loadComboBoxes();
            loadAuthors();
            loadEditors();
            loadTags();
            populate();
        }

        private void loadComboBoxes()
        {
            DataTable _authors = loFilSearch.getEmployeesByType("Reporter");
            loAuthors = loFilSearch.getEmployeesByType("Reporter"); ;
            cboAuthors.DataSource = _authors;
            cboAuthors.ValueMember = "EmployeeId";
            cboAuthors.DisplayMember = "Name";
            gridAuthors.Cols["Name"].Editor = cboAuthors;

            DataTable _editors = loFilSearch.getEmployeesByType("Editor");
            loEditors = loFilSearch.getEmployeesByType("Editor");
            cboEditors.DataSource = _editors;
            cboEditors.ValueMember = "EmployeeId";
            cboEditors.DisplayMember = "Initials";
            gridEditors.Cols["Initials"].Editor = cboEditors;
        }

        private void loadAuthors()
        {
            if (loDocument.DocAuthors != null && loDocument.DocAuthors.Length > 0)
            {
                foreach (string _id in loDocument.DocAuthors)
                {
                    gridAuthors.Rows.Count++;
                    gridAuthors.SetData(gridAuthors.Rows.Count - 1, 1, _id);
                    gridAuthors.SetData(gridAuthors.Rows.Count - 1, 0, getAuthor(_id));
                    gridAuthors.SetData(gridAuthors.Rows.Count - 1, 2, true);
                }
            }
        }

        private void loadEditors()
        {
            if (loDocument.DocEditors!=null && loDocument.DocEditors.Length > 0)
            {
                foreach (string _id in loDocument.DocEditors)
                {
                    gridEditors.Rows.Count++;
                    gridEditors.SetData(gridEditors.Rows.Count - 1, 1, _id);
                    gridEditors.SetData(gridEditors.Rows.Count - 1, 0, getEditor(_id));
                    gridEditors.SetData(gridEditors.Rows.Count - 1, 2, true);
                }
            }
        }

        private void loadTags()
        {
            if (loDocument.DocTags != null && loDocument.DocTags.Length > 0)
            {
                foreach (string _id in loDocument.getDocTagsArr())
                {
                    gridTags.Rows.Count++;
                    gridTags.SetData(gridTags.Rows.Count - 1, 0, _id);
                    gridTags.SetData(gridTags.Rows.Count - 1, 1, true);
                }
            }
        }

        private string getAuthor(string id)
        {
            DataView _dv = loAuthors.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = "EmployeeId = '" + id + "'";
            if (_dv.Count > 0)
            {
                return _dv[0]["Name"].ToString();
            }
            else
            {
                return "";
            }
        }

        private string getEditor(string id)
        {
            DataView _dv = loEditors.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = "EmployeeId = '" + id + "'";
            if (_dv.Count > 0)
            {
                return _dv[0]["Initials"].ToString();
            }
            else
            {
                return "";
            }
        }

        private void populate()
        {
            txtTitle.Text = loDocument.Title;
            txtDocumentId.Text = lDocumentId;
            //cboNewspaper.Text = loDocument.Newspaper;
            cboNewspaper.SelectedValue = loDocument.Newspaper;
            //cboSection.Text = loDocument.Section;
            cboSection.SelectedValue = loDocument.Section;
            dtpPublishedDate.Value = DateTime.Parse(loDocument.PublishedDate);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (loDocument!=null && lDocumentId!="")
                {
                    string _fileType = loDocument.Doctype;
                    string _filename = lDocumentId + _fileType;
                    if (_fileType == ".doc" || _fileType == ".docx")
                    {
                        object _missing = System.Reflection.Missing.Value;
                        Word.Application wordApp = new Word.Application();
                        Word.Document aDoc = null;

                        if (File.Exists(@"" + GlobalVariables.goFileServer + @"\" + _filename))
                        {
                            File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, Path.GetTempPath() + @"\" + _filename, true);
                            object readOnly = true;
                            object isVisible = true;
                            wordApp.Visible = true;
                            object path = Path.GetTempPath() + @"\" + _filename;
                            aDoc = wordApp.Documents.Open(ref path, ref _missing,
                                    ref readOnly, ref _missing, ref _missing, ref _missing,
                                    ref _missing, ref _missing, ref _missing, ref _missing,
                                    ref _missing, ref isVisible, ref _missing, ref _missing,
                                    ref _missing, ref _missing);

                            aDoc.Activate();
                            File.Delete(Path.GetTempPath() + @"\" + _filename);
                        }
                        else
                        {
                            MessageBox.Show("File does not exists in repository!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (File.Exists(@"" + GlobalVariables.goFileServer + @"\" + _filename))
                        {
                            File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, Path.GetTempPath() + @"\" + _filename, true);
                            //System.IO.FileInfo finfo = new System.IO.FileInfo(Path.GetTempPath() + @"\" + _filename);
                            //finfo.Attributes = System.IO.FileAttributes.ReadOnly;
                            Process.Start(Path.GetTempPath() + @"\" + _filename);
                            //finfo.Attributes = System.IO.FileAttributes.Normal;
                            //File.Delete(Path.GetTempPath() + @"\" + _filename);
                        }
                        else
                        {
                            MessageBox.Show("File does not exist in repository!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (loDocument != null && lDocumentId != "")
                {
                    string _fileType = loDocument.Doctype;
                    string _filename = lDocumentId + _fileType;
                    if (File.Exists(@"" + GlobalVariables.goFileServer + @"\" + _filename))
                    {
                        sfdSave.FileName = loDocument.Title;
                        sfdSave.Title = "Save Document";
                        if (_fileType == ".doc" || _fileType == ".txt" || _fileType == ".rtf")
                        {
                            cmnuDownloadDocument.Show(this.Left + 128, this.Top + 620);
                        }
                        else
                        {
                            sfdSave.Filter = "PDF (*.pdf)|*.pdf";
                            if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                                MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("File does not exists in repository!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btnRemoveAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this author?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    if (bool.Parse(gridAuthors.GetData(gridAuthors.Row, 2).ToString()))
                    {
                        if (loFilSearch.deleteAuthor(gridAuthors.GetData(gridAuthors.Row, "ID").ToString(), loDocument.DocumentId))
                        {
                            MessageBox.Show("Author deleted", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    gridAuthors.Rows.Remove(gridAuthors.Row);
                }
            }
            catch { }
        }

        private void btnRemoveEditor_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this editor?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    if (bool.Parse(gridEditors.GetData(gridEditors.Row, 2).ToString()))
                    {
                        if (loFilSearch.deleteEditor(gridEditors.GetData(gridEditors.Row, "ID").ToString(), loDocument.DocumentId))
                        {
                            MessageBox.Show("Editor deleted", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    gridEditors.Rows.Remove(gridEditors.Row);
                }
            }
            catch { }
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _rsp = MessageBox.Show("Are you sure you want to delete this Tag?", "DIIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    if (bool.Parse(gridTags.GetData(gridTags.Row, 1).ToString()))
                    {
                        if (loFilSearch.deleteTag(gridTags.GetData(gridTags.Row, 0).ToString(), loDocument.DocumentId))
                        {
                            MessageBox.Show("Tag deleted", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    gridTags.Rows.Remove(gridTags.Row);
                }
            }
            catch { }
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            gridAuthors.Rows.Count++;
            gridAuthors.SetData(gridAuthors.Rows.Count - 1, 2, false);
            btnSaveAuthors.Enabled = true;
        }

        private void btnAddEditor_Click(object sender, EventArgs e)
        {
            gridEditors.Rows.Count++;
            gridEditors.SetData(gridEditors.Rows.Count - 1, 2, false);
            btnSaveEditors.Enabled = true;
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            gridTags.Rows.Count++;
            gridTags.SetData(gridTags.Rows.Count - 1, 1, false);
            gridTags.Row = gridTags.Rows.Count - 1;
            btnSaveTags.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loDocument.Newspaper = cboNewspaper.SelectedValue.ToString();
            loDocument.Section = cboSection.SelectedValue.ToString();
            loDocument.PublishedDate = dtpPublishedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            
            if (loFilSearch.saveDocument(loDocument))
            {
                MessageBox.Show("Saving document successful", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was a problem in saving the document", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridAuthors_SelChange(object sender, EventArgs e)
        {
            if(gridAuthors.Col == 0 && !bool.Parse(gridAuthors.GetData(gridAuthors.Row, 2).ToString()))
            {
                gridAuthors.AllowEditing = true;
            }
            else
            {
                gridAuthors.AllowEditing = false;
            }
        }

        private void btnSaveAuthors_Click(object sender, EventArgs e)
        {
            string _str = "";
            bool _saved = false;
            for (int _row = 1; _row < gridAuthors.Rows.Count; _row++)
            {
                _saved = bool.Parse(gridAuthors.GetData(_row, "saved").ToString());
                if (!_saved)
                {
                    _str = _str + gridAuthors.GetData(_row, "ID").ToString() + ",";
                    gridAuthors.SetData(_row, "saved", true);
                }
            }
            if (_str.Length > 0)
            {
                _str = _str.Substring(0, _str.Length - 1);
                if (loFilSearch.saveAuthors(_str, loDocument.DocumentId))
                {
                    MessageBox.Show("Authors saved!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problem saving authors!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSaveAuthors.Enabled = false;
        }

        private void gridAuthors_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (gridAuthors.GetDataDisplay(gridAuthors.Row, 0) == "" && gridAuthors.GetDataDisplay(gridAuthors.Row, 1) == "")
            {
                gridAuthors.Rows.Remove(gridAuthors.Row);
            }
            else
            {
                gridAuthors.SetData(gridAuthors.Row, "ID", this.cboAuthors.SelectedValue.ToString());
            }
        }

        private void gridEditors_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (gridEditors.GetDataDisplay(gridEditors.Row, 0) == "" && gridEditors.GetDataDisplay(gridEditors.Row, 1) == "")
            {
                gridEditors.Rows.Remove(gridEditors.Row);
            }
            else
            {
                gridEditors.SetData(gridEditors.Row, "ID", this.cboEditors.SelectedValue.ToString());
            }
        }

        private void gridEditors_SelChange(object sender, EventArgs e)
        {
            if (gridEditors.Col == 0 && !bool.Parse(gridEditors.GetData(gridEditors.Row, 2).ToString()))
            {
                gridEditors.AllowEditing = true;
            }
            else
            {
                gridEditors.AllowEditing = false;
            }
        }

        private void btnSaveEditors_Click(object sender, EventArgs e)
        {
            string _str = "";
            bool _saved = false;
            for (int _row = 1; _row < gridEditors.Rows.Count; _row++)
            {
                _saved = bool.Parse(gridEditors.GetData(_row, "saved").ToString());
                if (!_saved)
                {
                    _str = _str + gridEditors.GetData(_row, "ID").ToString() + ",";
                    gridEditors.SetData(_row, "saved", true);
                }
            }
            if (_str.Length > 0)
            {
                _str = _str.Substring(0, _str.Length - 1);
                if (loFilSearch.saveEditors(_str, loDocument.DocumentId))
                {
                    MessageBox.Show("Editors saved!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problem saving editors!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSaveEditors.Enabled = false;
        }

        private void gridAuthors_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            DataView _dv = loAuthors.DefaultView;
            _dv.RowFilter = "";
            DataTable _temp = _dv.ToTable();
            for (int _row = 1; _row < gridAuthors.Rows.Count; _row++)
            {
                _dv = _temp.DefaultView;
                if (_row == e.Row)
                    continue;
                _dv.RowFilter = "Name <> '" + gridAuthors.GetDataDisplay(_row, 0).ToString() + "'";
                _temp = _dv.ToTable();
            }
            cboAuthors.DataSource = _temp;
            gridAuthors.Cols[0].Editor = cboAuthors;
        }

        private void gridEditors_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            DataView _dv = loEditors.DefaultView;
            _dv.RowFilter = "";
            DataTable _temp = _dv.ToTable();
            for (int _row = 1; _row < gridEditors.Rows.Count; _row++)
            {
                _dv = _temp.DefaultView;
                if (_row == e.Row)
                    continue;
                _dv.RowFilter = "Initials <> '" + gridEditors.GetDataDisplay(_row, 0).ToString() + "'";
                _temp = _dv.ToTable();
            }
            cboEditors.DataSource = _temp;
            gridEditors.Cols[0].Editor = cboEditors;
        }

        private void gridTags_SelChange(object sender, EventArgs e)
        {
            if (gridTags.Col == 0 && !bool.Parse(gridTags.GetData(gridTags.Row, 1).ToString()))
            {
                gridTags.AllowEditing = true;
            }
            else
            {
                gridTags.AllowEditing = false;
            }
        }

        private void gridTags_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (gridTags.GetDataDisplay(gridTags.Row, 0) == "")
            {
                gridTags.Rows.Remove(gridTags.Row);
            }
            else
            {
                string _newTag = gridTags.GetDataDisplay(gridTags.Row, 0).ToString();
                for (int _row = 1; _row < gridTags.Rows.Count; _row++)
                {
                    if (_newTag == gridTags.GetDataDisplay(_row, 0).ToString() && _row != gridTags.Row)
                    {
                        MessageBox.Show("Tag already exists!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridTags.Rows.Remove(gridTags.Row);
                    }
                }
            }
        }

        private void btnSaveTags_Click(object sender, EventArgs e)
        {
            string _str = "";
            bool _saved = false;
            for (int _row = 1; _row < gridTags.Rows.Count; _row++)
            {
                _saved = bool.Parse(gridTags.GetData(_row, "saved").ToString());
                if (!_saved)
                {
                    _str = _str + gridTags.GetData(_row, 0).ToString() + ",";
                    gridTags.SetData(_row, "saved", true);
                }
            }
            if (_str.Length > 0)
            {
                _str = _str.Substring(0, _str.Length - 1);
                if (loFilSearch.saveTags(_str, loDocument.DocumentId))
                {
                    MessageBox.Show("Tags saved!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problem saving tags!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSaveTags.Enabled = false;
        }

        private void tsmTxt_Click(object sender, EventArgs e)
        {
            if (loDocument.Doctype == ".txt")
            {
                sfdSave.Filter = "Text Document (*.txt)|*.txt";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Text Document (*.txt)|*.txt";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
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
            if (loDocument.Doctype == ".doc" || loDocument.Doctype == ".rtf")
            {
                sfdSave.Filter = "Word Document (*.doc)|*.doc";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Word Document (*.doc)|*.doc";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
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

        private void cboNewspaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSections();
        }

        private void tsmRtf_Click(object sender, EventArgs e)
        {
            if (loDocument.Doctype == ".doc" || loDocument.Doctype == ".rtf")
            {
                sfdSave.Filter = "Word Document (*.rtf)|*.rtf";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
                if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    File.Copy(@"" + GlobalVariables.goFileServer + @"\" + _filename, sfdSave.FileName);
                    MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sfdSave.Filter = "Word Document (*.rtf)|*.rtf";
                string _filename = loDocument.DocumentId + loDocument.Doctype;
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
