using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.Common.Global;
using System.IO;
using System.Diagnostics;
namespace EchoSystems.DIIA.FileSearch.Views
{
    public partial class ViewImage : Form
    {
        private string lImageId;
        private ImageBO loImage;
        private EchoSystems.DIIA.FileSearch.Controller.FileSearch loFilSearch;
        public ViewImage()
        {
            InitializeComponent();
        }
        public ViewImage(string pImageId)
        {
            InitializeComponent();
            lImageId = pImageId;
            loFilSearch = new EchoSystems.DIIA.FileSearch.Controller.FileSearch();
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {
            loImage = loFilSearch.getImage(lImageId);
            loadComboBoxes();
            loadTags();
            populate();
        }

        private void loadComboBoxes()
        {
            cboPhotographers.DataSource = loFilSearch.getEmployeesByType("Photographer");
            cboPhotographers.DisplayMember = "Name";
            cboPhotographers.ValueMember = "EmployeeId";
        }
        private void loadTags()
        {
            if (loImage.Tags != null && loImage.Tags.Length > 0)
            {
                foreach (string _id in loImage.getImageTagsArr())
                {
                    gridTags.Rows.Count++;
                    gridTags.SetData(gridTags.Rows.Count - 1, 0, _id);
                    gridTags.SetData(gridTags.Rows.Count - 1, 1, true);
                }
            }
        }
        private void populate()
        {
            txtTitle.Text = loImage.Title;
            txtCaption.Text = loImage.Caption;
            txtLocation.Text = loImage.Location;
            cboPhotographers.SelectedValue = loImage.PhotographerId;
            dtpDateTaken.Value = loImage.DateTaken;
            try
            {
                string[] _image = loImage.Path.Split('.');
                pbImagePreview.Image = GlobalFunctions.resizeImage(Image.FromFile(GlobalVariables.goImageServer + @"\" + lImageId + "." + _image[_image.Length-1]), pbImagePreview.Size);
            }catch
            {
                pbImagePreview.Image = GlobalFunctions.resizeImage(Image.FromFile("notfound.jpg"), pbImagePreview.Size);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            loImage.PhotographerId = cboPhotographers.SelectedValue.ToString();
            loImage.Location = txtLocation.Text;
            loImage.Caption = txtCaption.Text;
            loImage.DateTaken = dtpDateTaken.Value;
            loImage.ImageID = lImageId;
            if (loFilSearch.saveImage(loImage))
            {
                MessageBox.Show("Saving image successful", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was a problem in saving the image", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (loImage != null && lImageId != "")
                {
                    string[] _image = loImage.Path.Split('.');
                    string _fileType = _image[_image.Length - 1];
                    string _filename = loImage.ImageID + "." + _fileType;
                    if (File.Exists(@"" + GlobalVariables.goImageServer + @"\" + _filename))
                    {
                        sfdSave.FileName = loImage.Title + "." + _fileType;
                        sfdSave.Title = "Save Document";

                        if (sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            File.Copy(@"" + GlobalVariables.goImageServer + @"\" + _filename, sfdSave.FileName);
                            MessageBox.Show("Download successful!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Image does not exists in repository!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (loImage != null && lImageId != "")
                {
                    string[] _image = loImage.Path.Split('.');
                    string _fileType = _image[_image.Length - 1];
                    string _filename = lImageId + "." + _fileType;
                    
                    if (File.Exists(@"" + GlobalVariables.goImageServer + @"\" + _filename))
                    {
                        File.Copy(@"" + GlobalVariables.goImageServer + @"\" + _filename, Path.GetTempPath() + @"\" + _filename, true);
                        System.IO.FileInfo finfo = new System.IO.FileInfo(Path.GetTempPath() + @"\" + _filename);
                        finfo.Attributes = System.IO.FileAttributes.ReadOnly;
                        Process.Start(Path.GetTempPath() + @"\" + _filename);
                        File.Delete(Path.GetTempPath() + @"\" + _filename);
                    }
                    else
                    {
                        MessageBox.Show("Image does not exists in repository!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch
            {
            }
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
                        if (loFilSearch.deleteImageTag(gridTags.GetData(gridTags.Row, 0).ToString(), lImageId))
                        {
                            MessageBox.Show("Tag deleted", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    gridTags.Rows.Remove(gridTags.Row);
                }
            }
            catch { }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            gridTags.Rows.Count++;
            gridTags.SetData(gridTags.Rows.Count - 1, 1, false);
            btnSaveTags.Enabled = true;
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
                if (loFilSearch.saveImageTags(_str, lImageId))
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

    }
}
