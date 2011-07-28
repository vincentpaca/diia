namespace EchoSystems.DIIA.FileManager.Views
{
    partial class FileUpload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUpload));
            this.tlpFileUpload = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFileUpload = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.gridFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bwUploadFile = new System.ComponentModel.BackgroundWorker();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.tlpFileUpload.SuspendLayout();
            this.pnlFileUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpFileUpload
            // 
            this.tlpFileUpload.ColumnCount = 1;
            this.tlpFileUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFileUpload.Controls.Add(this.pnlFileUpload, 0, 1);
            this.tlpFileUpload.Controls.Add(this.gridFiles, 0, 0);
            this.tlpFileUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFileUpload.Location = new System.Drawing.Point(0, 0);
            this.tlpFileUpload.Name = "tlpFileUpload";
            this.tlpFileUpload.RowCount = 2;
            this.tlpFileUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFileUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFileUpload.Size = new System.Drawing.Size(684, 462);
            this.tlpFileUpload.TabIndex = 0;
            // 
            // pnlFileUpload
            // 
            this.pnlFileUpload.Controls.Add(this.btnRemoveFile);
            this.pnlFileUpload.Controls.Add(this.btnUpload);
            this.pnlFileUpload.Controls.Add(this.btnAddFile);
            this.pnlFileUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileUpload.Location = new System.Drawing.Point(3, 425);
            this.pnlFileUpload.Name = "pnlFileUpload";
            this.pnlFileUpload.Size = new System.Drawing.Size(678, 34);
            this.pnlFileUpload.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpload.Location = new System.Drawing.Point(595, 6);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddFile.Location = new System.Drawing.Point(514, 6);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "Add a File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // gridFiles
            // 
            this.gridFiles.ColumnInfo = resources.GetString("gridFiles.ColumnInfo");
            this.gridFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFiles.Location = new System.Drawing.Point(3, 3);
            this.gridFiles.Name = "gridFiles";
            this.gridFiles.Rows.Count = 1;
            this.gridFiles.Rows.DefaultSize = 17;
            this.gridFiles.Size = new System.Drawing.Size(678, 416);
            this.gridFiles.TabIndex = 1;
            // 
            // bwUploadFile
            // 
            this.bwUploadFile.WorkerReportsProgress = true;
            this.bwUploadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUploadFile_DoWork);
            this.bwUploadFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwUploadFile_ProgressChanged);
            this.bwUploadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwUploadFile_RunWorkerCompleted);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(9, 6);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 2;
            this.btnRemoveFile.Text = "Remove";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tlpFileUpload);
            this.Name = "FileUpload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Files";
            this.tlpFileUpload.ResumeLayout(false);
            this.pnlFileUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpFileUpload;
        private System.Windows.Forms.Panel pnlFileUpload;
        private C1.Win.C1FlexGrid.C1FlexGrid gridFiles;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnAddFile;
        private System.ComponentModel.BackgroundWorker bwUploadFile;
        private System.Windows.Forms.Button btnRemoveFile;

    }
}