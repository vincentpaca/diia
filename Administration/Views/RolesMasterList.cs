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

namespace EchoSystems.Administration.Views
{
    public partial class RolesMasterList : Form
    {

        Controller.Administration loAdministration;

        public RolesMasterList()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewRole _newRole = new NewRole();
            _newRole.ShowDialog(this);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewRole _viewRole = new ViewRole();
            _viewRole.RoleId = gridRoles.GetDataDisplay(gridRoles.Row, "RoleName");
            _viewRole.ShowDialog(this);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _res = MessageBox.Show("Are you sure you want to delete " + gridRoles.GetDataDisplay(gridRoles.Row, "RoleName") + "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_res == System.Windows.Forms.DialogResult.Yes)
                {
                    loAdministration.deleteRole(gridRoles.GetDataDisplay(gridRoles.Row, "RoleName"));
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred upon deleting role. Exception: " + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RolesMasterList_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref gridRoles, loAdministration.getRoles());
        }
    }
}
