namespace EchoSystems.Administration.Views
{
    partial class RolesMasterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesMasterList));
            this.tsRolesMasterList = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.gridRoles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsRolesMasterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRolesMasterList
            // 
            this.tsRolesMasterList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbView,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbClose});
            this.tsRolesMasterList.Location = new System.Drawing.Point(0, 0);
            this.tsRolesMasterList.Name = "tsRolesMasterList";
            this.tsRolesMasterList.Size = new System.Drawing.Size(653, 25);
            this.tsRolesMasterList.TabIndex = 1;
            this.tsRolesMasterList.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::EchoSystems.Administration.Properties.Resources.plus_16;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(51, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbView
            // 
            this.tsbView.Image = global::EchoSystems.Administration.Properties.Resources.search_16;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(52, 22);
            this.tsbView.Text = "View";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::EchoSystems.Administration.Properties.Resources.trash_16;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(60, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::EchoSystems.Administration.Properties.Resources.reload_16;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::EchoSystems.Administration.Properties.Resources.delete_16;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(56, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // gridRoles
            // 
            this.gridRoles.ColumnInfo = resources.GetString("gridRoles.ColumnInfo");
            this.gridRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRoles.Location = new System.Drawing.Point(0, 25);
            this.gridRoles.Name = "gridRoles";
            this.gridRoles.Rows.Count = 1;
            this.gridRoles.Rows.DefaultSize = 17;
            this.gridRoles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridRoles.Size = new System.Drawing.Size(653, 383);
            this.gridRoles.TabIndex = 2;
            // 
            // RolesMasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 408);
            this.Controls.Add(this.gridRoles);
            this.Controls.Add(this.tsRolesMasterList);
            this.Name = "RolesMasterList";
            this.ShowIcon = false;
            this.Text = "RolesMasterList";
            this.Load += new System.EventHandler(this.RolesMasterList_Load);
            this.tsRolesMasterList.ResumeLayout(false);
            this.tsRolesMasterList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRolesMasterList;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private C1.Win.C1FlexGrid.C1FlexGrid gridRoles;
    }
}