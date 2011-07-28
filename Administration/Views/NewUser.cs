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
    public partial class NewUser : Form
    {
        Controller.Administration loAdministration;

        public NewUser()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    loAdministration.insertUser(txtUserId.Text, txtPassword.Text, cboRole.SelectedValue.ToString(), cboDefaultSection.SelectedValue.ToString());
                    MessageBox.Show("New user successfully saved!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    UserMasterList _parent = Application.OpenForms["UserMasterList"] as UserMasterList;

                    _parent.GetType().GetMethod("refresh").Invoke(_parent, null);

                    ViewUser _viewUser = new ViewUser();
                    _viewUser.UserId = txtUserId.Text;
                    _viewUser.Role = cboRole.Text;
                    _viewUser.DefaultSection = cboDefaultSection.Text;
                    _viewUser.ShowDialog(_parent);
                }
                else
                {
                    MessageBox.Show("Passwords do not match!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred upon saving new user. Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void NewUser_Load(object sender, EventArgs e)
        {
            cboRole.DataSource = loAdministration.getRoles();
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleName";

            cboDefaultSection.DataSource = loAdministration.getSections();
            cboDefaultSection.DisplayMember = "Section";
            cboDefaultSection.ValueMember = "SectionId";
        }
    }
}
