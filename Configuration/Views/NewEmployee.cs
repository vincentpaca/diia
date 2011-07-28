using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.Common.Global;
using EchoSystems.DIIA.Configuration.Controller;
using EchoSystems.DIIA.Configuration.Models;

namespace EchoSystems.DIIA.Configuration.Views
{
    public partial class NewEmployee : Form
    {
        Controller.Configuration loConfiguration;
        string lSender = "";

        public NewEmployee()
        {
            InitializeComponent();
            loConfiguration = new Controller.Configuration();
        }

        public NewEmployee(string pSender)
            : this()
        {
            lSender = pSender;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string _empID = loConfiguration.insertEmployee(txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, txtInitials.Text, cboEmployeeType.SelectedValue.ToString());
                MessageBox.Show("New employee successfully saved!", "Save Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_empID != null || _empID != "")
                {
                    //if the one who called this window was from the master list window click,
                    //refresh the masterlist at the back of this window
                    if (lSender== "")
                    {
                        EmployeeMasterList _parent = Application.OpenForms["EmployeeMasterList"] as EmployeeMasterList;

                        this.Hide();
                        _parent.GetType().GetMethod("refresh").Invoke(_parent, null);

                        ViewEmployee _view = new ViewEmployee();
                        _view.EmployeeId = _empID;
                        _view.ShowDialog(_parent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured upon saving new employee.Exception: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally { Close(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            //fill the combo box with data
            cboEmployeeType.DataSource = loConfiguration.getEmployeeTypes();
            cboEmployeeType.DisplayMember = "EmployeeType";
            cboEmployeeType.ValueMember = "EmployeeType";

            //if the button sender clicked add new author
            //set the default employee type in the combo box as Reporter
            //if the button sender clicked add new editor
            //set the employee type to Editor
            if (lSender == "btnAddNewAuthor")
            {
                cboEmployeeType.Text = "Reporter";
            }
            else if (lSender == "btnAddNewEditor")
            {
                cboEmployeeType.Text = "Editor";
            }
        }
    }
}
