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
    public partial class UserMasterList : Form
    {
        Controller.Administration loAdministration;

        public UserMasterList()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewUser _newUser = new NewUser();
            _newUser.ShowDialog(this);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DialogResult _res = MessageBox.Show("Are you sure you want to delete " + gridUsers.GetDataDisplay(gridUsers.Row, "userID") + "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_res == System.Windows.Forms.DialogResult.Yes)
            {
                loAdministration.deleteUser(gridUsers.GetDataDisplay(gridUsers.Row, "userID"));
                refresh();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref gridUsers, loAdministration.getUsers());
            gridUsers.AutoSizeCols();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserMasterList_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void gridUsers_DoubleClick(object sender, EventArgs e)
        {
            ViewUser _viewUser = new ViewUser();
            _viewUser.UserId = gridUsers.GetDataDisplay(gridUsers.Row, "userID");
            _viewUser.ShowDialog(this);
        }
    }
}
