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
    public partial class LoginUI : Form
    {
        Controller.Administration loAdministration;

        public LoginUI()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                loAdministration = new Controller.Administration();
                bool _userExists = loAdministration.loginUser(this.txtUsername.Text, this.txtPassword.Text);

                if (_userExists == true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong username and password combination!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid username and password combination", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult _res = MessageBox.Show("Are you sure you want to cancel logging in? This will exit the application.", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_res == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
