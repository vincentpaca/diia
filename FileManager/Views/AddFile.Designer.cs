namespace EchoSystems.DIIA.FileManager.Views
{
    partial class AddFile
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
            this.lblDocumentTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNewspaper = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.dtpPublishedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAuthor = new System.Windows.Forms.Button();
            this.btnAddNewAuthor = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.gridAuthors = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveEditor = new System.Windows.Forms.Button();
            this.btnAddNewEditor = new System.Windows.Forms.Button();
            this.btnAddEditor = new System.Windows.Forms.Button();
            this.gridEditors = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEditors)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocumentTitle
            // 
            this.lblDocumentTitle.AutoSize = true;
            this.lblDocumentTitle.Location = new System.Drawing.Point(12, 49);
            this.lblDocumentTitle.Name = "lblDocumentTitle";
            this.lblDocumentTitle.Size = new System.Drawing.Size(30, 13);
            this.lblDocumentTitle.TabIndex = 15;
            this.lblDocumentTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 46);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(268, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Newspaper:";
            // 
            // cboNewspaper
            // 
            this.cboNewspaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewspaper.FormattingEnabled = true;
            this.cboNewspaper.Location = new System.Drawing.Point(100, 72);
            this.cboNewspaper.Name = "cboNewspaper";
            this.cboNewspaper.Size = new System.Drawing.Size(268, 21);
            this.cboNewspaper.TabIndex = 3;
            this.cboNewspaper.SelectedIndexChanged += new System.EventHandler(this.cboNewspaper_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Section:";
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(100, 99);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(268, 21);
            this.cboSection.TabIndex = 5;
            // 
            // dtpPublishedDate
            // 
            this.dtpPublishedDate.Location = new System.Drawing.Point(100, 126);
            this.dtpPublishedDate.Name = "dtpPublishedDate";
            this.dtpPublishedDate.Size = new System.Drawing.Size(268, 20);
            this.dtpPublishedDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Published Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveAuthor);
            this.groupBox1.Controls.Add(this.btnAddNewAuthor);
            this.groupBox1.Controls.Add(this.btnAddAuthor);
            this.groupBox1.Controls.Add(this.gridAuthors);
            this.groupBox1.Location = new System.Drawing.Point(12, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 129);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Author(s)";
            // 
            // btnRemoveAuthor
            // 
            this.btnRemoveAuthor.Location = new System.Drawing.Point(7, 100);
            this.btnRemoveAuthor.Name = "btnRemoveAuthor";
            this.btnRemoveAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAuthor.TabIndex = 3;
            this.btnRemoveAuthor.Text = "Remove";
            this.btnRemoveAuthor.UseVisualStyleBackColor = true;
            this.btnRemoveAuthor.Click += new System.EventHandler(this.btnRemoveAuthor_Click);
            // 
            // btnAddNewAuthor
            // 
            this.btnAddNewAuthor.Location = new System.Drawing.Point(275, 100);
            this.btnAddNewAuthor.Name = "btnAddNewAuthor";
            this.btnAddNewAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewAuthor.TabIndex = 2;
            this.btnAddNewAuthor.Text = "Add New";
            this.btnAddNewAuthor.UseVisualStyleBackColor = true;
            this.btnAddNewAuthor.Click += new System.EventHandler(this.btnAddNewAuthor_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.Location = new System.Drawing.Point(194, 100);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAddAuthor.TabIndex = 1;
            this.btnAddAuthor.Text = "Add Author";
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // gridAuthors
            // 
            this.gridAuthors.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:340;Name:\"Name\";Caption:\"Name\";AllowResizing:False;S" +
                "tyleFixed:\"TextAlign:CenterCenter;\";}\t1{Name:\"ID\";Visible:False;}\t";
            this.gridAuthors.Location = new System.Drawing.Point(6, 19);
            this.gridAuthors.Name = "gridAuthors";
            this.gridAuthors.Rows.Count = 1;
            this.gridAuthors.Rows.DefaultSize = 17;
            this.gridAuthors.Size = new System.Drawing.Size(344, 75);
            this.gridAuthors.TabIndex = 0;
            this.gridAuthors.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridAuthors_AfterEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveEditor);
            this.groupBox2.Controls.Add(this.btnAddNewEditor);
            this.groupBox2.Controls.Add(this.btnAddEditor);
            this.groupBox2.Controls.Add(this.gridEditors);
            this.groupBox2.Location = new System.Drawing.Point(12, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 129);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor(s)";
            // 
            // btnRemoveEditor
            // 
            this.btnRemoveEditor.Location = new System.Drawing.Point(7, 100);
            this.btnRemoveEditor.Name = "btnRemoveEditor";
            this.btnRemoveEditor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveEditor.TabIndex = 3;
            this.btnRemoveEditor.Text = "Remove";
            this.btnRemoveEditor.UseVisualStyleBackColor = true;
            this.btnRemoveEditor.Click += new System.EventHandler(this.btnRemoveEditor_Click);
            // 
            // btnAddNewEditor
            // 
            this.btnAddNewEditor.Location = new System.Drawing.Point(275, 100);
            this.btnAddNewEditor.Name = "btnAddNewEditor";
            this.btnAddNewEditor.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewEditor.TabIndex = 2;
            this.btnAddNewEditor.Text = "Add New";
            this.btnAddNewEditor.UseVisualStyleBackColor = true;
            this.btnAddNewEditor.Click += new System.EventHandler(this.btnAddNewEditor_Click);
            // 
            // btnAddEditor
            // 
            this.btnAddEditor.Location = new System.Drawing.Point(194, 100);
            this.btnAddEditor.Name = "btnAddEditor";
            this.btnAddEditor.Size = new System.Drawing.Size(75, 23);
            this.btnAddEditor.TabIndex = 1;
            this.btnAddEditor.Text = "Add Editor";
            this.btnAddEditor.UseVisualStyleBackColor = true;
            this.btnAddEditor.Click += new System.EventHandler(this.btnAddEditor_Click);
            // 
            // gridEditors
            // 
            this.gridEditors.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:340;Name:\"Initials\";Caption:\"Initials\";AllowResizing" +
                ":False;StyleFixed:\"TextAlign:CenterCenter;\";}\t1{Name:\"ID\";Visible:False;}\t";
            this.gridEditors.Location = new System.Drawing.Point(6, 19);
            this.gridEditors.Name = "gridEditors";
            this.gridEditors.Rows.Count = 1;
            this.gridEditors.Rows.DefaultSize = 17;
            this.gridEditors.Size = new System.Drawing.Size(344, 75);
            this.gridEditors.TabIndex = 0;
            this.gridEditors.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridEditors_AfterEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTags);
            this.groupBox3.Location = new System.Drawing.Point(12, 422);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 82);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tag(s)";
            // 
            // txtTags
            // 
            this.txtTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTags.Location = new System.Drawing.Point(3, 16);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(350, 63);
            this.txtTags.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tags should be separated by a comma";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(212, 533);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 12;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 533);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Browse:";
            // 
            // txtBrowse
            // 
            this.txtBrowse.Location = new System.Drawing.Point(100, 20);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(268, 20);
            this.txtBrowse.TabIndex = 0;
            this.txtBrowse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBrowse_MouseClick);
            // 
            // AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 564);
            this.ControlBox = false;
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpPublishedDate);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboNewspaper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDocumentTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a File";
            this.Load += new System.EventHandler(this.AddFile_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEditors)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDocumentTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNewspaper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.DateTimePicker dtpPublishedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid gridAuthors;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddEditor;
        private C1.Win.C1FlexGrid.C1FlexGrid gridEditors;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnAddNewAuthor;
        private System.Windows.Forms.Button btnAddNewEditor;
        private System.Windows.Forms.Button btnRemoveAuthor;
        private System.Windows.Forms.Button btnRemoveEditor;

    }
}