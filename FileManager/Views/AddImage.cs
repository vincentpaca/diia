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
using EchoSystems.Common.Enum;
using EchoSystems.DIIA.FileManager.Controller;
using EchoSystems.DIIA.FileManager.Models;

namespace EchoSystems.DIIA.FileManager
{
    public partial class AddImage : Form
    {
        Image loImagePreview;
        Image loImageThumbnail;

        ImageBO loImage;

        Configuration.Controller.Configuration loConfiguration;

        public ClosingType ClosingType
        {
            get;
            set;
        }

        public string PhotographerName
        {
            get;
            set;
        }

        public Image ThumbnailImage
        {
            get;
            set;
        }

        public AddImage()
        {
            InitializeComponent();
            loConfiguration = new Configuration.Controller.Configuration();
        }

        private void txtBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();
            _fileDialog.Title = "Select a file";
            _fileDialog.Filter = "JPG(*.jpg)|*.jpg|JPEG(*.jpeg)|*.jpeg|BMP(*.bmp)|*.bmp|PNG(*.png)|*.png|TIFF(*.tiff)|*.tiff";
            _fileDialog.ShowDialog(this);

            txtBrowse.Text = _fileDialog.FileName;
            txtTitle.Text = GlobalFunctions.parseTitleFromFile(txtBrowse.Text);

            loImagePreview = Image.FromFile(txtBrowse.Text);
            loImagePreview = GlobalFunctions.resizeImage(loImagePreview, new Size(429, 196));
            pbImagePreview.Image = loImagePreview;
            pbImagePreview.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void setPreivew()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClosingType = Common.Enum.ClosingType.Cancelled;
            Close();
        }

        private void AddImage_Load(object sender, EventArgs e)
        {
            cboPhotographers.DataSource = loConfiguration.getEmployeesByType("Photographer");
            cboPhotographers.DisplayMember = "Name";
            cboPhotographers.ValueMember = "EmployeeId";
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            loImage = new ImageBO();
            loImage.ImageID = "";
            loImage.Title = txtTitle.Text;
            loImage.Path = @"" + txtBrowse.Text;
            loImage.Type = Path.GetExtension(txtBrowse.Text);
            loImage.Caption = txtCaption.Text;
            loImage.Location = txtLocation.Text;
            loImage.PhotographerId = cboPhotographers.SelectedValue.ToString();
            loImage.DateTaken = dtpDateTaken.Value;
            loImage.Tags = txtTags.Text;
            PhotographerName = cboPhotographers.Text;
            ThumbnailImage = loImageThumbnail;

            ClosingType = Common.Enum.ClosingType.Accepted;
            Close();
        }

        public ImageBO getImage()
        {
            return loImage;
        }
    }
}
