using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.Administration.Controller;
using EchoSystems.Administration.Models;

namespace EchoSystems.Administration.Views
{
    public partial class ViewUser : Form
    {
        User loUser;
        Controller.Administration loAdministration;

        public string UserId
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }

        public string DefaultSection
        {
            get;
            set;
        }

        public ViewUser()
        {
            InitializeComponent();
            loAdministration = new Controller.Administration();
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            cboRole.DataSource = loAdministration.getRoles();
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleName";

            cboDefaultSection.DataSource = loAdministration.getSections();
            cboDefaultSection.DisplayMember = "Section";
            cboDefaultSection.ValueMember = "SectionId";

            loUser = loAdministration.getUserDetailsById(UserId);

            txtUserId.Text = UserId;
            cboRole.Text = loUser.role;
            cboDefaultSection.SelectedValue = loUser.defaultSection;
            txtPassword.Text = loUser.password;
            txtConfirmPassword.Text = loUser.password;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    loAdministration.updateUser(txtUserId.Text, "", cboRole.SelectedValue.ToString(), cboDefaultSection.SelectedValue.ToString());
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
    }
}
