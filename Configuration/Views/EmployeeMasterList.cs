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

namespace EchoSystems.DIIA.Configuration.Views
{
    public partial class EmployeeMasterList : Form
    {
        Controller.Configuration loConfiguration;

        ViewEmployee frmViewEmployee;

        public EmployeeMasterList()
        {
            InitializeComponent();
            loConfiguration = new Controller.Configuration();
            frmViewEmployee = new ViewEmployee();
        }

        private void EmployeeMasterList_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            NewEmployee _newEmployee = new NewEmployee();
            _newEmployee.ShowDialog(this);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref gridEmployees, loConfiguration.getEmployees());
            gridEmployees.AutoSizeCols();
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            frmViewEmployee.EmployeeId = gridEmployees.GetDataDisplay(gridEmployees.Row, "EmployeeId");
            frmViewEmployee.ShowDialog(this);
        }

        private void gridEmployees_Click(object sender, EventArgs e)
        {

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {            
            DialogResult _res = MessageBox.Show("Are you sure you want to delete " + gridEmployees.GetDataDisplay(gridEmployees.Row, "Name") + "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_res == System.Windows.Forms.DialogResult.Yes)
            {
                loConfiguration.deleteEmployee(gridEmployees.GetDataDisplay(gridEmployees.Row, "EmployeeId"));
                refresh();                
            }
        }
    }
}
