namespace EchoSystems.DIIA.FileManager.Views
{
    partial class ImageUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageUpload));
            this.tlpImageUpload = new System.Windows.Forms.TableLayoutPanel();
            this.pnlimageUpload = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.gridImages = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bwImageUpload = new System.ComponentModel.BackgroundWorker();
            this.tlpImageUpload.SuspendLayout();
            this.pnlimageUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImages)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpImageUpload
            // 
            this.tlpImageUpload.ColumnCount = 1;
            this.tlpImageUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageUpload.Controls.Add(this.pnlimageUpload, 0, 1);
            this.tlpImageUpload.Controls.Add(this.gridImages, 0, 0);
            this.tlpImageUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageUpload.Location = new System.Drawing.Point(0, 0);
            this.tlpImageUpload.Name = "tlpImageUpload";
            this.tlpImageUpload.RowCount = 2;
            this.tlpImageUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpImageUpload.Size = new System.Drawing.Size(684, 462);
            this.tlpImageUpload.TabIndex = 0;
            // 
            // pnlimageUpload
            // 
            this.pnlimageUpload.Controls.Add(this.btnRemove);
            this.pnlimageUpload.Controls.Add(this.btnUpload);
            this.pnlimageUpload.Controls.Add(this.btnAddImage);
            this.pnlimageUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlimageUpload.Location = new System.Drawing.Point(3, 425);
            this.pnlimageUpload.Name = "pnlimageUpload";
            this.pnlimageUpload.Size = new System.Drawing.Size(678, 34);
            this.pnlimageUpload.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemove.Location = new System.Drawing.Point(9, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
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
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddImage.Location = new System.Drawing.Point(514, 6);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 0;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // gridImages
            // 
            this.gridImages.ColumnInfo = resources.GetString("gridImages.ColumnInfo");
            this.gridImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImages.Location = new System.Drawing.Point(3, 3);
            this.gridImages.Name = "gridImages";
            this.gridImages.Rows.Count = 1;
            this.gridImages.Rows.DefaultSize = 17;
            this.gridImages.Size = new System.Drawing.Size(678, 416);
            this.gridImages.TabIndex = 2;
            // 
            // bwImageUpload
            // 
            this.bwImageUpload.WorkerReportsProgress = true;
            this.bwImageUpload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImageUpload_DoWork);
            this.bwImageUpload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwImageUpload_ProgressChanged);
            this.bwImageUpload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImageUpload_RunWorkerCompleted);
            // 
            // ImageUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tlpImageUpload);
            this.Name = "ImageUpload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageUpload";
            this.tlpImageUpload.ResumeLayout(false);
            this.pnlimageUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpImageUpload;
        private System.Windows.Forms.Panel pnlimageUpload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnAddImage;
        private C1.Win.C1FlexGrid.C1FlexGrid gridImages;
        private System.ComponentModel.BackgroundWorker bwImageUpload;
        private System.Windows.Forms.Button btnRemove;
    }
}