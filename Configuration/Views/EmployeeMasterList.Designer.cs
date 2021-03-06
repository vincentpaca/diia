﻿namespace EchoSystems.DIIA.Configuration.Views
{
    partial class EmployeeMasterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMasterList));
            this.tsEmployeeMasterList = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.gridEmployees = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tsEmployeeMasterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // tsEmployeeMasterList
            // 
            this.tsEmployeeMasterList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbView,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbClose});
            this.tsEmployeeMasterList.Location = new System.Drawing.Point(0, 0);
            this.tsEmployeeMasterList.Name = "tsEmployeeMasterList";
            this.tsEmployeeMasterList.Size = new System.Drawing.Size(592, 25);
            this.tsEmployeeMasterList.TabIndex = 0;
            this.tsEmployeeMasterList.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::EchoSystems.DIIA.Configuration.Properties.Resources.plus_16;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(51, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbView
            // 
            this.tsbView.Image = global::EchoSystems.DIIA.Configuration.Properties.Resources.search_16;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(52, 22);
            this.tsbView.Text = "View";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::EchoSystems.DIIA.Configuration.Properties.Resources.trash_16;
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
            this.tsbRefresh.Image = global::EchoSystems.DIIA.Configuration.Properties.Resources.reload_16;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::EchoSystems.DIIA.Configuration.Properties.Resources.delete_16;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(56, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // gridEmployees
            // 
            this.gridEmployees.ColumnInfo = resources.GetString("gridEmployees.ColumnInfo");
            this.gridEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployees.Location = new System.Drawing.Point(0, 25);
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.Rows.Count = 1;
            this.gridEmployees.Rows.DefaultSize = 17;
            this.gridEmployees.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridEmployees.Size = new System.Drawing.Size(592, 386);
            this.gridEmployees.TabIndex = 1;
            this.gridEmployees.DoubleClick += new System.EventHandler(this.gridEmployees_Click);
            // 
            // EmployeeMasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 411);
            this.Controls.Add(this.gridEmployees);
            this.Controls.Add(this.tsEmployeeMasterList);
            this.Name = "EmployeeMasterList";
            this.ShowIcon = false;
            this.Text = "Employee Master List";
            this.Load += new System.EventHandler(this.EmployeeMasterList_Load);
            this.tsEmployeeMasterList.ResumeLayout(false);
            this.tsEmployeeMasterList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsEmployeeMasterList;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private C1.Win.C1FlexGrid.C1FlexGrid gridEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
    }
}