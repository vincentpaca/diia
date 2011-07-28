namespace EchoSystems.Administration.Views
{
    partial class SystemRoleUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemRoleUI));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRoleName = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdMenus = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdForms = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdPrivileges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenus)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdForms)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrivileges)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // cboRoleName
            // 
            this.cboRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleName.FormattingEnabled = true;
            this.cboRoleName.Location = new System.Drawing.Point(99, 22);
            this.cboRoleName.Name = "cboRoleName";
            this.cboRoleName.Size = new System.Drawing.Size(277, 21);
            this.cboRoleName.TabIndex = 2;
            this.cboRoleName.SelectedIndexChanged += new System.EventHandler(this.cboRoleName_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(99, 56);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(277, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 469);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdMenus);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Menus";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdMenus
            // 
            this.grdMenus.AllowEditing = false;
            this.grdMenus.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.grdMenus.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdMenus.ColumnInfo = resources.GetString("grdMenus.ColumnInfo");
            this.grdMenus.ExtendLastCol = true;
            this.grdMenus.Location = new System.Drawing.Point(6, 6);
            this.grdMenus.Name = "grdMenus";
            this.grdMenus.Rows.Count = 1;
            this.grdMenus.Rows.DefaultSize = 17;
            this.grdMenus.Size = new System.Drawing.Size(584, 431);
            this.grdMenus.TabIndex = 0;
            this.grdMenus.SelChange += new System.EventHandler(this.grdMenus_SelChange);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdForms);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "System Forms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdForms
            // 
            this.grdForms.AllowEditing = false;
            this.grdForms.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.grdForms.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.grdForms.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdForms.ColumnInfo = resources.GetString("grdForms.ColumnInfo");
            this.grdForms.ExtendLastCol = true;
            this.grdForms.Location = new System.Drawing.Point(6, 6);
            this.grdForms.Name = "grdForms";
            this.grdForms.Rows.Count = 1;
            this.grdForms.Rows.DefaultSize = 17;
            this.grdForms.Size = new System.Drawing.Size(584, 431);
            this.grdForms.TabIndex = 0;
            this.grdForms.SelChange += new System.EventHandler(this.grdForms_SelChange);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdPrivileges);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "System Privileges";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdPrivileges
            // 
            this.grdPrivileges.AllowEditing = false;
            this.grdPrivileges.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.grdPrivileges.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.grdPrivileges.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdPrivileges.ColumnInfo = resources.GetString("grdPrivileges.ColumnInfo");
            this.grdPrivileges.ExtendLastCol = true;
            this.grdPrivileges.Location = new System.Drawing.Point(6, 6);
            this.grdPrivileges.Name = "grdPrivileges";
            this.grdPrivileges.Rows.Count = 1;
            this.grdPrivileges.Rows.DefaultSize = 17;
            this.grdPrivileges.Size = new System.Drawing.Size(584, 434);
            this.grdPrivileges.TabIndex = 0;
            this.grdPrivileges.SelChange += new System.EventHandler(this.grdPrivileges_SelChange);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(474, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(546, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SystemRoleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 565);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cboRoleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemRoleUI";
            this.Text = "System Menu Role";
            this.Load += new System.EventHandler(this.SystemRoleUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMenus)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdForms)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrivileges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoleName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private C1.Win.C1FlexGrid.C1FlexGrid grdMenus;
        private C1.Win.C1FlexGrid.C1FlexGrid grdForms;
        private C1.Win.C1FlexGrid.C1FlexGrid grdPrivileges;
    }
}