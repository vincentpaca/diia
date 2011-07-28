namespace EchoSystems.DIIA.FileSearch.Views
{
    partial class SearchUI
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
            this.components = new System.ComponentModel.Container();
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.tabDocuments = new System.Windows.Forms.TabPage();
            this.txtDocumentPreview = new System.Windows.Forms.RichTextBox();
            this.pnlDocumentSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteDocument = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.llblDocumentLast = new System.Windows.Forms.LinkLabel();
            this.llblDocumentNext = new System.Windows.Forms.LinkLabel();
            this.llblDocumentPrev = new System.Windows.Forms.LinkLabel();
            this.llblDocumentFirst = new System.Windows.Forms.LinkLabel();
            this.lblDocumentDisplay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDocumentFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDocumentTo = new System.Windows.Forms.DateTimePicker();
            this.chkDocumentDateFilter = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.btnDownloadDocument = new System.Windows.Forms.Button();
            this.btnDocumentSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.cboNewspaper = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumentSearch = new System.Windows.Forms.TextBox();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.llblImageFirst = new System.Windows.Forms.LinkLabel();
            this.llblImagePrev = new System.Windows.Forms.LinkLabel();
            this.llblImageNext = new System.Windows.Forms.LinkLabel();
            this.llblImageLast = new System.Windows.Forms.LinkLabel();
            this.lblImageDisplay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpImageTo = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpImageFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chkImageDateFilter = new System.Windows.Forms.CheckBox();
            this.btnDownloadImage = new System.Windows.Forms.Button();
            this.btnImageSearch = new System.Windows.Forms.Button();
            this.txtImageSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.cmnuDownloadDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRtf = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSearch.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabImages.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmnuDownloadDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSearch
            // 
            this.tabSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSearch.Controls.Add(this.tabDocuments);
            this.tabSearch.Controls.Add(this.tabImages);
            this.tabSearch.Location = new System.Drawing.Point(12, 12);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(914, 473);
            this.tabSearch.TabIndex = 0;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.txtDocumentPreview);
            this.tabDocuments.Controls.Add(this.pnlDocumentSearch);
            this.tabDocuments.Controls.Add(this.btnDeleteDocument);
            this.tabDocuments.Controls.Add(this.groupBox2);
            this.tabDocuments.Controls.Add(this.groupBox1);
            this.tabDocuments.Controls.Add(this.label4);
            this.tabDocuments.Controls.Add(this.cboSection);
            this.tabDocuments.Controls.Add(this.btnDownloadDocument);
            this.tabDocuments.Controls.Add(this.btnDocumentSearch);
            this.tabDocuments.Controls.Add(this.label3);
            this.tabDocuments.Controls.Add(this.label2);
            this.tabDocuments.Controls.Add(this.cboDocType);
            this.tabDocuments.Controls.Add(this.cboNewspaper);
            this.tabDocuments.Controls.Add(this.label1);
            this.tabDocuments.Controls.Add(this.txtDocumentSearch);
            this.tabDocuments.Location = new System.Drawing.Point(4, 22);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocuments.Size = new System.Drawing.Size(906, 447);
            this.tabDocuments.TabIndex = 0;
            this.tabDocuments.Text = "Documents";
            this.tabDocuments.UseVisualStyleBackColor = true;
            // 
            // txtDocumentPreview
            // 
            this.txtDocumentPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentPreview.BackColor = System.Drawing.Color.White;
            this.txtDocumentPreview.Location = new System.Drawing.Point(511, 113);
            this.txtDocumentPreview.Name = "txtDocumentPreview";
            this.txtDocumentPreview.ReadOnly = true;
            this.txtDocumentPreview.Size = new System.Drawing.Size(389, 328);
            this.txtDocumentPreview.TabIndex = 23;
            this.txtDocumentPreview.Text = "";
            // 
            // pnlDocumentSearch
            // 
            this.pnlDocumentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDocumentSearch.AutoScroll = true;
            this.pnlDocumentSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlDocumentSearch.Location = new System.Drawing.Point(6, 113);
            this.pnlDocumentSearch.Name = "pnlDocumentSearch";
            this.pnlDocumentSearch.Size = new System.Drawing.Size(499, 328);
            this.pnlDocumentSearch.TabIndex = 22;
            // 
            // btnDeleteDocument
            // 
            this.btnDeleteDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDocument.Location = new System.Drawing.Point(770, 27);
            this.btnDeleteDocument.Name = "btnDeleteDocument";
            this.btnDeleteDocument.Size = new System.Drawing.Size(54, 23);
            this.btnDeleteDocument.TabIndex = 19;
            this.btnDeleteDocument.Text = "Delete";
            this.btnDeleteDocument.UseVisualStyleBackColor = true;
            this.btnDeleteDocument.Click += new System.EventHandler(this.btnDeleteDocument_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.llblDocumentLast);
            this.groupBox2.Controls.Add(this.llblDocumentNext);
            this.groupBox2.Controls.Add(this.llblDocumentPrev);
            this.groupBox2.Controls.Add(this.llblDocumentFirst);
            this.groupBox2.Controls.Add(this.lblDocumentDisplay);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(511, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 51);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pagination";
            // 
            // llblDocumentLast
            // 
            this.llblDocumentLast.AutoSize = true;
            this.llblDocumentLast.Location = new System.Drawing.Point(271, 26);
            this.llblDocumentLast.Name = "llblDocumentLast";
            this.llblDocumentLast.Size = new System.Drawing.Size(42, 13);
            this.llblDocumentLast.TabIndex = 5;
            this.llblDocumentLast.TabStop = true;
            this.llblDocumentLast.Text = "Last >>";
            this.llblDocumentLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLast_LinkClicked);
            // 
            // llblDocumentNext
            // 
            this.llblDocumentNext.AutoSize = true;
            this.llblDocumentNext.Location = new System.Drawing.Point(227, 26);
            this.llblDocumentNext.Name = "llblDocumentNext";
            this.llblDocumentNext.Size = new System.Drawing.Size(38, 13);
            this.llblDocumentNext.TabIndex = 4;
            this.llblDocumentNext.TabStop = true;
            this.llblDocumentNext.Text = "Next >";
            this.llblDocumentNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNext_LinkClicked);
            // 
            // llblDocumentPrev
            // 
            this.llblDocumentPrev.AutoSize = true;
            this.llblDocumentPrev.Location = new System.Drawing.Point(183, 26);
            this.llblDocumentPrev.Name = "llblDocumentPrev";
            this.llblDocumentPrev.Size = new System.Drawing.Size(38, 13);
            this.llblDocumentPrev.TabIndex = 3;
            this.llblDocumentPrev.TabStop = true;
            this.llblDocumentPrev.Text = "< Prev";
            this.llblDocumentPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPrev_LinkClicked);
            // 
            // llblDocumentFirst
            // 
            this.llblDocumentFirst.AutoSize = true;
            this.llblDocumentFirst.Location = new System.Drawing.Point(135, 26);
            this.llblDocumentFirst.Name = "llblDocumentFirst";
            this.llblDocumentFirst.Size = new System.Drawing.Size(41, 13);
            this.llblDocumentFirst.TabIndex = 2;
            this.llblDocumentFirst.TabStop = true;
            this.llblDocumentFirst.Text = "<< First";
            this.llblDocumentFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFirst_LinkClicked);
            // 
            // lblDocumentDisplay
            // 
            this.lblDocumentDisplay.AutoSize = true;
            this.lblDocumentDisplay.Location = new System.Drawing.Point(67, 26);
            this.lblDocumentDisplay.Name = "lblDocumentDisplay";
            this.lblDocumentDisplay.Size = new System.Drawing.Size(24, 13);
            this.lblDocumentDisplay.TabIndex = 1;
            this.lblDocumentDisplay.Text = "0/0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Displaying :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpDocumentFrom);
            this.groupBox1.Controls.Add(this.dtpDocumentTo);
            this.groupBox1.Controls.Add(this.chkDocumentDateFilter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 51);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advance";
            // 
            // dtpDocumentFrom
            // 
            this.dtpDocumentFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpDocumentFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocumentFrom.Location = new System.Drawing.Point(72, 19);
            this.dtpDocumentFrom.Name = "dtpDocumentFrom";
            this.dtpDocumentFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpDocumentFrom.TabIndex = 14;
            // 
            // dtpDocumentTo
            // 
            this.dtpDocumentTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpDocumentTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocumentTo.Location = new System.Drawing.Point(233, 19);
            this.dtpDocumentTo.Name = "dtpDocumentTo";
            this.dtpDocumentTo.Size = new System.Drawing.Size(120, 20);
            this.dtpDocumentTo.TabIndex = 16;
            // 
            // chkDocumentDateFilter
            // 
            this.chkDocumentDateFilter.AutoSize = true;
            this.chkDocumentDateFilter.Location = new System.Drawing.Point(6, 23);
            this.chkDocumentDateFilter.Name = "chkDocumentDateFilter";
            this.chkDocumentDateFilter.Size = new System.Drawing.Size(15, 14);
            this.chkDocumentDateFilter.TabIndex = 11;
            this.chkDocumentDateFilter.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "To : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "From : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Section";
            // 
            // cboSection
            // 
            this.cboSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(551, 29);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(119, 21);
            this.cboSection.TabIndex = 9;
            // 
            // btnDownloadDocument
            // 
            this.btnDownloadDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadDocument.Location = new System.Drawing.Point(830, 27);
            this.btnDownloadDocument.Name = "btnDownloadDocument";
            this.btnDownloadDocument.Size = new System.Drawing.Size(70, 23);
            this.btnDownloadDocument.TabIndex = 8;
            this.btnDownloadDocument.Text = "Download";
            this.btnDownloadDocument.UseVisualStyleBackColor = true;
            this.btnDownloadDocument.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDocumentSearch
            // 
            this.btnDocumentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentSearch.Location = new System.Drawing.Point(732, 27);
            this.btnDocumentSearch.Name = "btnDocumentSearch";
            this.btnDocumentSearch.Size = new System.Drawing.Size(32, 23);
            this.btnDocumentSearch.TabIndex = 6;
            this.btnDocumentSearch.Text = "GO";
            this.btnDocumentSearch.UseVisualStyleBackColor = true;
            this.btnDocumentSearch.Click += new System.EventHandler(this.btnDocumentSearch_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Document Type";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Newspaper";
            // 
            // cboDocType
            // 
            this.cboDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point(676, 29);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(50, 21);
            this.cboDocType.TabIndex = 3;
            // 
            // cboNewspaper
            // 
            this.cboNewspaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNewspaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewspaper.FormattingEnabled = true;
            this.cboNewspaper.Location = new System.Drawing.Point(451, 29);
            this.cboNewspaper.Name = "cboNewspaper";
            this.cboNewspaper.Size = new System.Drawing.Size(94, 21);
            this.cboNewspaper.TabIndex = 2;
            this.cboNewspaper.SelectedIndexChanged += new System.EventHandler(this.cboNewspaper_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search : ";
            // 
            // txtDocumentSearch
            // 
            this.txtDocumentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentSearch.Location = new System.Drawing.Point(6, 29);
            this.txtDocumentSearch.Name = "txtDocumentSearch";
            this.txtDocumentSearch.Size = new System.Drawing.Size(439, 20);
            this.txtDocumentSearch.TabIndex = 0;
            this.txtDocumentSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentSearch_KeyPress);
            // 
            // tabImages
            // 
            this.tabImages.Controls.Add(this.btnDeleteImage);
            this.tabImages.Controls.Add(this.pnlImages);
            this.tabImages.Controls.Add(this.pnlPreview);
            this.tabImages.Controls.Add(this.groupBox4);
            this.tabImages.Controls.Add(this.groupBox3);
            this.tabImages.Controls.Add(this.btnDownloadImage);
            this.tabImages.Controls.Add(this.btnImageSearch);
            this.tabImages.Controls.Add(this.txtImageSearch);
            this.tabImages.Controls.Add(this.label8);
            this.tabImages.Location = new System.Drawing.Point(4, 22);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(906, 447);
            this.tabImages.TabIndex = 1;
            this.tabImages.Text = "Images";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteImage.Location = new System.Drawing.Point(765, 27);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(54, 23);
            this.btnDeleteImage.TabIndex = 9;
            this.btnDeleteImage.Text = "Delete";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // pnlImages
            // 
            this.pnlImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImages.AutoScroll = true;
            this.pnlImages.Location = new System.Drawing.Point(6, 113);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(499, 328);
            this.pnlImages.TabIndex = 8;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPreview.Controls.Add(this.txtCaption);
            this.pnlPreview.Controls.Add(this.picPreview);
            this.pnlPreview.Location = new System.Drawing.Point(511, 113);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(389, 328);
            this.pnlPreview.TabIndex = 7;
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.Location = new System.Drawing.Point(3, 250);
            this.txtCaption.Multiline = true;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.ReadOnly = true;
            this.txtCaption.Size = new System.Drawing.Size(383, 75);
            this.txtCaption.TabIndex = 1;
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(3, 3);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(383, 241);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.llblImageFirst);
            this.groupBox4.Controls.Add(this.llblImagePrev);
            this.groupBox4.Controls.Add(this.llblImageNext);
            this.groupBox4.Controls.Add(this.llblImageLast);
            this.groupBox4.Controls.Add(this.lblImageDisplay);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(511, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 51);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pagination";
            // 
            // llblImageFirst
            // 
            this.llblImageFirst.AutoSize = true;
            this.llblImageFirst.Location = new System.Drawing.Point(136, 26);
            this.llblImageFirst.Name = "llblImageFirst";
            this.llblImageFirst.Size = new System.Drawing.Size(41, 13);
            this.llblImageFirst.TabIndex = 9;
            this.llblImageFirst.TabStop = true;
            this.llblImageFirst.Text = "<< First";
            this.llblImageFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblImageFirst_LinkClicked);
            // 
            // llblImagePrev
            // 
            this.llblImagePrev.AutoSize = true;
            this.llblImagePrev.Location = new System.Drawing.Point(183, 26);
            this.llblImagePrev.Name = "llblImagePrev";
            this.llblImagePrev.Size = new System.Drawing.Size(38, 13);
            this.llblImagePrev.TabIndex = 8;
            this.llblImagePrev.TabStop = true;
            this.llblImagePrev.Text = "< Prev";
            this.llblImagePrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblImagePrev_LinkClicked);
            // 
            // llblImageNext
            // 
            this.llblImageNext.AutoSize = true;
            this.llblImageNext.Location = new System.Drawing.Point(227, 26);
            this.llblImageNext.Name = "llblImageNext";
            this.llblImageNext.Size = new System.Drawing.Size(38, 13);
            this.llblImageNext.TabIndex = 6;
            this.llblImageNext.TabStop = true;
            this.llblImageNext.Text = "Next >";
            this.llblImageNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblImageNext_LinkClicked);
            // 
            // llblImageLast
            // 
            this.llblImageLast.AutoSize = true;
            this.llblImageLast.Location = new System.Drawing.Point(271, 26);
            this.llblImageLast.Name = "llblImageLast";
            this.llblImageLast.Size = new System.Drawing.Size(42, 13);
            this.llblImageLast.TabIndex = 7;
            this.llblImageLast.TabStop = true;
            this.llblImageLast.Text = "Last >>";
            this.llblImageLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblImageLast_LinkClicked);
            // 
            // lblImageDisplay
            // 
            this.lblImageDisplay.AutoSize = true;
            this.lblImageDisplay.Location = new System.Drawing.Point(55, 29);
            this.lblImageDisplay.Name = "lblImageDisplay";
            this.lblImageDisplay.Size = new System.Drawing.Size(24, 13);
            this.lblImageDisplay.TabIndex = 6;
            this.lblImageDisplay.Text = "0/0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Displaying :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtpImageTo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dtpImageFrom);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.chkImageDateFilter);
            this.groupBox3.Location = new System.Drawing.Point(6, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 51);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advance";
            // 
            // dtpImageTo
            // 
            this.dtpImageTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpImageTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImageTo.Location = new System.Drawing.Point(233, 19);
            this.dtpImageTo.Name = "dtpImageTo";
            this.dtpImageTo.Size = new System.Drawing.Size(120, 20);
            this.dtpImageTo.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "To : ";
            // 
            // dtpImageFrom
            // 
            this.dtpImageFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpImageFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImageFrom.Location = new System.Drawing.Point(72, 19);
            this.dtpImageFrom.Name = "dtpImageFrom";
            this.dtpImageFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpImageFrom.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "From : ";
            // 
            // chkImageDateFilter
            // 
            this.chkImageDateFilter.AutoSize = true;
            this.chkImageDateFilter.Location = new System.Drawing.Point(6, 23);
            this.chkImageDateFilter.Name = "chkImageDateFilter";
            this.chkImageDateFilter.Size = new System.Drawing.Size(15, 14);
            this.chkImageDateFilter.TabIndex = 0;
            this.chkImageDateFilter.UseVisualStyleBackColor = true;
            // 
            // btnDownloadImage
            // 
            this.btnDownloadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadImage.Location = new System.Drawing.Point(825, 27);
            this.btnDownloadImage.Name = "btnDownloadImage";
            this.btnDownloadImage.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadImage.TabIndex = 3;
            this.btnDownloadImage.Text = "Download";
            this.btnDownloadImage.UseVisualStyleBackColor = true;
            this.btnDownloadImage.Click += new System.EventHandler(this.btnDownloadImage_Click);
            // 
            // btnImageSearch
            // 
            this.btnImageSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageSearch.Location = new System.Drawing.Point(727, 27);
            this.btnImageSearch.Name = "btnImageSearch";
            this.btnImageSearch.Size = new System.Drawing.Size(32, 23);
            this.btnImageSearch.TabIndex = 2;
            this.btnImageSearch.Text = "GO";
            this.btnImageSearch.UseVisualStyleBackColor = true;
            this.btnImageSearch.Click += new System.EventHandler(this.btnImageSearch_Click);
            // 
            // txtImageSearch
            // 
            this.txtImageSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageSearch.Location = new System.Drawing.Point(6, 29);
            this.txtImageSearch.Name = "txtImageSearch";
            this.txtImageSearch.Size = new System.Drawing.Size(715, 20);
            this.txtImageSearch.TabIndex = 1;
            this.txtImageSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImageSearch_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Search :";
            // 
            // cmnuDownloadDocument
            // 
            this.cmnuDownloadDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmText,
            this.tsmDoc,
            this.tsmRtf});
            this.cmnuDownloadDocument.Name = "cmnuDownloadDocument";
            this.cmnuDownloadDocument.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmText
            // 
            this.tsmText.Name = "tsmText";
            this.tsmText.Size = new System.Drawing.Size(152, 22);
            this.tsmText.Text = ".txt";
            this.tsmText.Click += new System.EventHandler(this.tsmText_Click);
            // 
            // tsmDoc
            // 
            this.tsmDoc.Name = "tsmDoc";
            this.tsmDoc.Size = new System.Drawing.Size(152, 22);
            this.tsmDoc.Text = ".doc";
            this.tsmDoc.Click += new System.EventHandler(this.tsmDoc_Click);
            // 
            // tsmRtf
            // 
            this.tsmRtf.Name = "tsmRtf";
            this.tsmRtf.Size = new System.Drawing.Size(152, 22);
            this.tsmRtf.Text = ".rtf";
            this.tsmRtf.Click += new System.EventHandler(this.tsmRtf_Click);
            // 
            // SearchUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 497);
            this.Controls.Add(this.tabSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SearchUI";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchUI_Load);
            this.Resize += new System.EventHandler(this.SearchUI_Resize);
            this.tabSearch.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabDocuments.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabImages.ResumeLayout(false);
            this.tabImages.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cmnuDownloadDocument.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tabDocuments;
        private System.Windows.Forms.TabPage tabImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocumentSearch;
        private System.Windows.Forms.ComboBox cboNewspaper;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDocumentSearch;
        private System.Windows.Forms.Button btnDownloadDocument;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.CheckBox chkDocumentDateFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDocumentFrom;
        private System.Windows.Forms.DateTimePicker dtpDocumentTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDocumentDisplay;
        private System.Windows.Forms.LinkLabel llblDocumentLast;
        private System.Windows.Forms.LinkLabel llblDocumentNext;
        private System.Windows.Forms.LinkLabel llblDocumentPrev;
        private System.Windows.Forms.LinkLabel llblDocumentFirst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImageSearch;
        private System.Windows.Forms.Button btnDownloadImage;
        private System.Windows.Forms.Button btnImageSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblImageDisplay;
        private System.Windows.Forms.LinkLabel llblImageLast;
        private System.Windows.Forms.LinkLabel llblImageNext;
        private System.Windows.Forms.LinkLabel llblImageFirst;
        private System.Windows.Forms.LinkLabel llblImagePrev;
        private System.Windows.Forms.DateTimePicker dtpImageTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpImageFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkImageDateFilter;
        private System.Windows.Forms.FlowLayoutPanel pnlImages;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Button btnDeleteDocument;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.FlowLayoutPanel pnlDocumentSearch;
        private System.Windows.Forms.ContextMenuStrip cmnuDownloadDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmText;
        private System.Windows.Forms.ToolStripMenuItem tsmDoc;
        private System.Windows.Forms.RichTextBox txtDocumentPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmRtf;
    }
}