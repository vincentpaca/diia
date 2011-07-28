using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EchoSystems.DIIA.Configuration;
using EchoSystems.DIIA.Configuration.Models;

namespace EchoSystems.DIIA.Configuration.Views
{
    public partial class ViewEmployee : Form
    {
        Controller.Configuration loConfiguration;

        public string EmployeeId
        {
            get;
            set;
        }

        public ViewEmployee()
        {
            InitializeComponent();
            loConfiguration = new Controller.Configuration();
        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {
            cboEmployeeType.DataSource = loConfiguration.getEmployeeTypes();
            cboEmployeeType.DisplayMember = "EmployeeType";
            cboEmployeeType.ValueMember = "EmployeeType";


            Employee _oEmployee = loConfiguration.getEmployeeDetailsByID(EmployeeId);
            txtFirstName.Text = _oEmployee.FirstName;
            txtLastName.Text = _oEmployee.LastName;
            txtMiddleName.Text = _oEmployee.MiddleName;
            txtInitials.Text = _oEmployee.Initials;
            cboEmployeeType.SelectedText = _oEmployee.EmployeeType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                loConfiguration.updateEmployee(EmployeeId, txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, txtInitials.Text, cboEmployeeType.SelectedValue.ToString());
                MessageBox.Show("Employee successfully updated", "Update Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured upon updating new employee.Exception: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
