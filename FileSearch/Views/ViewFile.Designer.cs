namespace EchoSystems.DIIA.FileSearch.Views
{
    partial class ViewFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewFile));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPublishedDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNewspaper = new System.Windows.Forms.ComboBox();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveAuthors = new System.Windows.Forms.Button();
            this.btnRemoveAuthor = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.gridAuthors = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveEditors = new System.Windows.Forms.Button();
            this.btnRemoveEditor = new System.Windows.Forms.Button();
            this.btnAddEditor = new System.Windows.Forms.Button();
            this.gridEditors = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveTags = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.gridTags = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDocumentId = new System.Windows.Forms.TextBox();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.cmnuDownloadDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRtf = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEditors)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTags)).BeginInit();
            this.cmnuDownloadDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(97, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(269, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Newspaper";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Section";
            // 
            // dtpPublishedDate
            // 
            this.dtpPublishedDate.Location = new System.Drawing.Point(97, 92);
            this.dtpPublishedDate.Name = "dtpPublishedDate";
            this.dtpPublishedDate.Size = new System.Drawing.Size(269, 20);
            this.dtpPublishedDate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Published Date";
            // 
            // cboNewspaper
            // 
            this.cboNewspaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewspaper.FormattingEnabled = true;
            this.cboNewspaper.Location = new System.Drawing.Point(97, 38);
            this.cboNewspaper.Name = "cboNewspaper";
            this.cboNewspaper.Size = new System.Drawing.Size(269, 21);
            this.cboNewspaper.TabIndex = 8;
            this.cboNewspaper.SelectedIndexChanged += new System.EventHandler(this.cboNewspaper_SelectedIndexChanged);
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(97, 65);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(269, 21);
            this.cboSection.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveAuthors);
            this.groupBox1.Controls.Add(this.btnRemoveAuthor);
            this.groupBox1.Controls.Add(this.btnAddAuthor);
            this.groupBox1.Controls.Add(this.gridAuthors);
            this.groupBox1.Location = new System.Drawing.Point(14, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Author(s)";
            // 
            // btnSaveAuthors
            // 
            this.btnSaveAuthors.Enabled = false;
            this.btnSaveAuthors.Location = new System.Drawing.Point(111, 100);
            this.btnSaveAuthors.Name = "btnSaveAuthors";
            this.btnSaveAuthors.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAuthors.TabIndex = 14;
            this.btnSaveAuthors.Text = "Save";
            this.btnSaveAuthors.UseVisualStyleBackColor = true;
            this.btnSaveAuthors.Click += new System.EventHandler(this.btnSaveAuthors_Click);
            // 
            // btnRemoveAuthor
            // 
            this.btnRemoveAuthor.Location = new System.Drawing.Point(273, 100);
            this.btnRemoveAuthor.Name = "btnRemoveAuthor";
            this.btnRemoveAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAuthor.TabIndex = 13;
            this.btnRemoveAuthor.Text = "Delete";
            this.btnRemoveAuthor.UseVisualStyleBackColor = true;
            this.btnRemoveAuthor.Click += new System.EventHandler(this.btnRemoveAuthor_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.Location = new System.Drawing.Point(192, 100);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAddAuthor.TabIndex = 12;
            this.btnAddAuthor.Text = "Add";
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // gridAuthors
            // 
            this.gridAuthors.ColumnInfo = resources.GetString("gridAuthors.ColumnInfo");
            this.gridAuthors.ExtendLastCol = true;
            this.gridAuthors.Location = new System.Drawing.Point(6, 19);
            this.gridAuthors.Name = "gridAuthors";
            this.gridAuthors.Rows.Count = 1;
            this.gridAuthors.Rows.DefaultSize = 17;
            this.gridAuthors.Size = new System.Drawing.Size(342, 75);
            this.gridAuthors.TabIndex = 11;
            this.gridAuthors.SelChange += new System.EventHandler(this.gridAuthors_SelChange);
            this.gridAuthors.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridAuthors_BeforeEdit);
            this.gridAuthors.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridAuthors_AfterEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveEditors);
            this.groupBox2.Controls.Add(this.btnRemoveEditor);
            this.groupBox2.Controls.Add(this.btnAddEditor);
            this.groupBox2.Controls.Add(this.gridEditors);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 129);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor(s)";
            // 
            // btnSaveEditors
            // 
            this.btnSaveEditors.Enabled = false;
            this.btnSaveEditors.Location = new System.Drawing.Point(111, 100);
            this.btnSaveEditors.Name = "btnSaveEditors";
            this.btnSaveEditors.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEditors.TabIndex = 3;
            this.btnSaveEditors.Text = "Save";
            this.btnSaveEditors.UseVisualStyleBackColor = true;
            this.btnSaveEditors.Click += new System.EventHandler(this.btnSaveEditors_Click);
            // 
            // btnRemoveEditor
            // 
            this.btnRemoveEditor.Location = new System.Drawing.Point(273, 100);
            this.btnRemoveEditor.Name = "btnRemoveEditor";
            this.btnRemoveEditor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveEditor.TabIndex = 2;
            this.btnRemoveEditor.Text = "Delete";
            this.btnRemoveEditor.UseVisualStyleBackColor = true;
            this.btnRemoveEditor.Click += new System.EventHandler(this.btnRemoveEditor_Click);
            // 
            // btnAddEditor
            // 
            this.btnAddEditor.Location = new System.Drawing.Point(192, 100);
            this.btnAddEditor.Name = "btnAddEditor";
            this.btnAddEditor.Size = new System.Drawing.Size(75, 23);
            this.btnAddEditor.TabIndex = 1;
            this.btnAddEditor.Text = "Add";
            this.btnAddEditor.UseVisualStyleBackColor = true;
            this.btnAddEditor.Click += new System.EventHandler(this.btnAddEditor_Click);
            // 
            // gridEditors
            // 
            this.gridEditors.ColumnInfo = resources.GetString("gridEditors.ColumnInfo");
            this.gridEditors.ExtendLastCol = true;
            this.gridEditors.Location = new System.Drawing.Point(6, 19);
            this.gridEditors.Name = "gridEditors";
            this.gridEditors.Rows.Count = 1;
            this.gridEditors.Rows.DefaultSize = 17;
            this.gridEditors.Size = new System.Drawing.Size(342, 75);
            this.gridEditors.TabIndex = 0;
            this.gridEditors.SelChange += new System.EventHandler(this.gridEditors_SelChange);
            this.gridEditors.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridEditors_BeforeEdit);
            this.gridEditors.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridEditors_AfterEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSaveTags);
            this.groupBox3.Controls.Add(this.btnRemoveTag);
            this.groupBox3.Controls.Add(this.btnAddTag);
            this.groupBox3.Controls.Add(this.gridTags);
            this.groupBox3.Location = new System.Drawing.Point(12, 388);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 186);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tag(s)";
            // 
            // btnSaveTags
            // 
            this.btnSaveTags.Enabled = false;
            this.btnSaveTags.Location = new System.Drawing.Point(111, 157);
            this.btnSaveTags.Name = "btnSaveTags";
            this.btnSaveTags.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTags.TabIndex = 3;
            this.btnSaveTags.Text = "Save";
            this.btnSaveTags.UseVisualStyleBackColor = true;
            this.btnSaveTags.Click += new System.EventHandler(this.btnSaveTags_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Location = new System.Drawing.Point(273, 157);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTag.TabIndex = 2;
            this.btnRemoveTag.Text = "Delete";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(192, 157);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(75, 23);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // gridTags
            // 
            this.gridTags.ColumnInfo = resources.GetString("gridTags.ColumnInfo");
            this.gridTags.ExtendLastCol = true;
            this.gridTags.Location = new System.Drawing.Point(6, 19);
            this.gridTags.Name = "gridTags";
            this.gridTags.Rows.Count = 1;
            this.gridTags.Rows.DefaultSize = 17;
            this.gridTags.Size = new System.Drawing.Size(342, 132);
            this.gridTags.TabIndex = 0;
            this.gridTags.SelChange += new System.EventHandler(this.gridTags_SelChange);
            this.gridTags.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridTags_AfterEdit);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(129, 580);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 14;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(48, 580);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 15;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(291, 580);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDocumentId
            // 
            this.txtDocumentId.Location = new System.Drawing.Point(185, 12);
            this.txtDocumentId.Name = "txtDocumentId";
            this.txtDocumentId.Size = new System.Drawing.Size(100, 20);
            this.txtDocumentId.TabIndex = 18;
            // 
            // cmnuDownloadDocument
            // 
            this.cmnuDownloadDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTxt,
            this.tsmDoc,
            this.tsmRtf});
            this.cmnuDownloadDocument.Name = "cmnuDownloadDocument";
            this.cmnuDownloadDocument.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmTxt
            // 
            this.tsmTxt.Name = "tsmTxt";
            this.tsmTxt.Size = new System.Drawing.Size(152, 22);
            this.tsmTxt.Text = ".txt";
            this.tsmTxt.Click += new System.EventHandler(this.tsmTxt_Click);
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
            // ViewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 615);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.cboNewspaper);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpPublishedDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDocumentId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Document";
            this.Load += new System.EventHandler(this.ViewFile_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEditors)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTags)).EndInit();
            this.cmnuDownloadDocument.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPublishedDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNewspaper;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid gridAuthors;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnRemoveAuthor;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid gridEditors;
        private System.Windows.Forms.Button btnRemoveEditor;
        private System.Windows.Forms.Button btnAddEditor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDocumentId;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private C1.Win.C1FlexGrid.C1FlexGrid gridTags;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnSaveAuthors;
        private System.Windows.Forms.Button btnSaveEditors;
        private System.Windows.Forms.Button btnSaveTags;
        private System.Windows.Forms.ContextMenuStrip cmnuDownloadDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmDoc;
        private System.Windows.Forms.ToolStripMenuItem tsmTxt;
        private System.Windows.Forms.ToolStripMenuItem tsmRtf;
    }
}