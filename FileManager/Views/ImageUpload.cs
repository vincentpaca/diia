using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.DIIA.FileManager.Controller;
using EchoSystems.Common.Views;

namespace EchoSystems.DIIA.FileManager.Views
{
    public partial class ImageUpload : Form
    {
        ImageBO loImage;
        Controller.FileManager loFileManager;

        LoadingForm _loadingForm;

        public string lFileName
        {
            get;
            set;
        }

        public ImageUpload()
        {
            InitializeComponent();
            loFileManager = new Controller.FileManager();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            AddImage _addImage = new AddImage();
            _addImage.ShowDialog(this);

            if (_addImage.ClosingType == Common.Enum.ClosingType.Accepted)
            {
                loImage = _addImage.getImage();
                gridImages.Rows.Count++;
                gridImages.SetData(gridImages.Rows.Count - 1, "Title", loImage.Title);
                gridImages.SetData(gridImages.Rows.Count - 1, "Local Path", loImage.Path);
                gridImages.SetData(gridImages.Rows.Count - 1, "Caption", loImage.Caption);
                gridImages.SetData(gridImages.Rows.Count - 1, "Location", loImage.Location);
                gridImages.SetData(gridImages.Rows.Count - 1, "Photographer", _addImage.PhotographerName);
                gridImages.SetData(gridImages.Rows.Count - 1, "Photographer ID", loImage.PhotographerId);
                gridImages.SetData(gridImages.Rows.Count - 1, "Thumbnail", _addImage.ThumbnailImage);
                gridImages.SetData(gridImages.Rows.Count - 1, "Date Taken", loImage.DateTaken);
                gridImages.SetData(gridImages.Rows.Count - 1, "Tags", loImage.Tags);
                gridImages.SetData(gridImages.Rows.Count - 1, "Type", loImage.Type);

                gridImages.AutoSizeRows();
                gridImages.AutoSizeCols();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bwImageUpload.RunWorkerAsync();
            _loadingForm = new LoadingForm();
            _loadingForm.ShowIcon = false;
            _loadingForm.ShowInTaskbar = false;
            _loadingForm.ShowDialog(this);
        }

        public void reportProgress(string pFileName, int pProgress)
        {
            lFileName = pFileName;
            bwImageUpload.ReportProgress(pProgress);
        }

        private void bwImageUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            if (gridImages.Rows.Count > 1)
            {
                loFileManager.ImageUpload = this;
                loFileManager.uploadImages(this.gridImages);

                MessageBox.Show("Images uploaded successfully!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //gridImages.Rows.Count = 1;
            }
            else
            {
                MessageBox.Show("There are no images in the queue", "No Images In Queue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bwImageUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    _loadingForm.setProgress("Saving " + lFileName + " to database...");
                    break;
                case 2:
                    _loadingForm.setProgress("Setting tags...");
                    break;
                case 3:
                    _loadingForm.setProgress("Setting presumed tags...");
                    break;
                case 4:
                    _loadingForm.setProgress("Uploading " + lFileName + " to image server...");
                    break;
                case 5:
                    _loadingForm.setProgress("Done!");
                    break;
            }
        }

        private void bwImageUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _loadingForm.Close();
            gridImages.Rows.Count = 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gridImages.Rows.Count <= 1)
            {
                return;
            }

            DialogResult _res = MessageBox.Show("Are you sure you want to remove the image for upload?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_res == System.Windows.Forms.DialogResult.Yes)
            {
                gridImages.RemoveItem(gridImages.Row);
            }
        }
    }
}
