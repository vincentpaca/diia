using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.Administration.Controller;
using EchoSystems.Common.Global;
using EchoSystems.Administration.Models;

namespace EchoSystems.Administration.Views
{
    public partial class ViewRole : Form
    {
        Role loRole;
        Controller.Administration loAdministration;

        public string RoleId
        {
            get;
            set;
        }

        public ViewRole()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void ViewRole_Load(object sender, EventArgs e)
        {
            loRole = new Role(RoleId);
            txtDescription.Text = loRole.Description;
            txtRoleName.Text = loRole.RoleName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                loAdministration.updateRole(this.txtRoleName.Text, this.txtDescription.Text);
                MessageBox.Show("New role updated successfully!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred upon updating role. Exception: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
