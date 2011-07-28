using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.Administration.Controller;

namespace EchoSystems.Administration.Views
{
    public partial class NewRole : Form
    {
        Controller.Administration loAdministration;

        public NewRole()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                loAdministration.saveRole(txtRoleName.Text, txtDescription.Text);
                MessageBox.Show("New role saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RolesMasterList _parent = Application.OpenForms["RolesMasterList"] as RolesMasterList;
                _parent.GetType().GetMethod("refresh").Invoke(_parent, null);

                this.Hide();

                ViewRole _view = new ViewRole();
                _view.RoleId = txtRoleName.Text;
                _view.ShowDialog(_parent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred upon saving new role. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
