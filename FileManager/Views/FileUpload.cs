using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.Common.Enum;
using EchoSystems.Common.Views;
using EchoSystems.DIIA.FileManager.Controller;

namespace EchoSystems.DIIA.FileManager.Views
{
    public partial class FileUpload : Form
    {
        Document loDocument;
        Controller.FileManager loFileManager;

        LoadingForm _loadingForm;

        string lFileName;

        public FileUpload()
        {
            InitializeComponent();
            loFileManager = new Controller.FileManager();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            AddFile _addFile = new AddFile();
            _addFile.ShowDialog(this);
            if (_addFile.ClosingType == ClosingType.Accepted)
            {
                loDocument = _addFile.getDocument();
                gridFiles.Rows.Count++;
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Local Path", loDocument.Path);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Title", loDocument.Title);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Doc Type", loDocument.Doctype);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Newspaper", loDocument.Newspaper);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Section", loDocument.Section);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Published Date", loDocument.PublishedDate);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Names", _addFile.Authors);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Initials", _addFile.Editors);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Section Name", _addFile.Section);

                string _authors = "";
                foreach(string _str in loDocument.DocAuthors)
                {
                    _authors += _str + ",";
                }

                gridFiles.SetData(gridFiles.Rows.Count - 1, "Authors", _authors);

                string _editors = "";
                foreach (string _str in loDocument.DocEditors)
                {
                    _editors += _str + ",";
                }

                gridFiles.SetData(gridFiles.Rows.Count - 1, "Editors", _editors);
                gridFiles.SetData(gridFiles.Rows.Count - 1, "Tags", loDocument.DocTags);

                gridFiles.AutoSizeRows();
                gridFiles.AutoSizeCols();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bwUploadFile.RunWorkerAsync();
            _loadingForm = new LoadingForm();
            _loadingForm.ShowIcon = false;
            _loadingForm.ShowInTaskbar = false;
            _loadingForm.ShowDialog(this);
        }

        public void reportProgress(string pFileName, int pProgress)
        {
            lFileName = pFileName;
            bwUploadFile.ReportProgress(pProgress);
        }

        private void bwUploadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            if (gridFiles.Rows.Count > 1)
            {
                loFileManager.FileUpload = this;
                loFileManager.uploadFiles(this.gridFiles);

                //disable button to avoid double clicks
                //btnUpload.Enabled = false;

                MessageBox.Show("Files uploaded successfully!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //gridFiles.Rows.Count = 1;
            }
            else
            {
                MessageBox.Show("There are no files in the queue", "No Files In Queue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bwUploadFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    _loadingForm.setProgress("Saving " + lFileName + " to database...");
                    break;
                case 2:
                    _loadingForm.setProgress("Associating " + lFileName + " to its authors...");
                    break;
                case 3:
                    _loadingForm.setProgress("Associating " + lFileName + " to its editors...");
                    break;
                case 4:
                    _loadingForm.setProgress("Setting tags...");
                    break;
                case 5:
                    _loadingForm.setProgress("Setting presumed tags...");
                    break;
                case 6:
                    _loadingForm.setProgress("Reading and analyzing " + lFileName + "...");
                    break;
                case 7:
                    _loadingForm.setProgress("Done!");
                    break;
            }
        }

        private void bwUploadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _loadingForm.Close();

            //enable the upload button
            btnUpload.Enabled = true;


            gridFiles.Rows.Count = 1;
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (gridFiles.Rows.Count <= 1)
            {
                return;
            }

            DialogResult _res = MessageBox.Show("Are you sure you want to remove the file for upload?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_res == System.Windows.Forms.DialogResult.Yes)
            {
                gridFiles.RemoveItem(gridFiles.Row);
            }
        }
    }
}
