using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using EchoSystems.Common.Global;
using EchoSystems.DIIA.Configuration.Controller;
namespace EchoSystems.DIIA.Configuration.Views
{
    public partial class Logs : Form
    {
        private EchoSystems.DIIA.Configuration.Controller.Configuration loConfiguration;
        public Logs()
        {
            InitializeComponent();
            loConfiguration = new EchoSystems.DIIA.Configuration.Controller.Configuration();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            gridLogs.Rows.Count = 1;
            GlobalFunctions.bindDataTableToFlexGrid(ref gridLogs, loConfiguration.getLogs(dtpFrom.Value, dtpTo.Value, cboUser.Text));
            gridLogs.AutoSizeCols();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            DataTable _dt = loConfiguration.getUsers();
            DataRow _dRow = _dt.NewRow();
            _dRow["userID"] = "";
            _dt.Rows.Add(_dRow);
            cboUser.DataSource = _dt;
            cboUser.DisplayMember = "userID";
            cboUser.SelectedIndex = cboUser.Items.Count - 1;
        }

        private void gridLogs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Assembly _newAssembly;
            Type _type;
            string _id = gridLogs.GetDataDisplay(gridLogs.Row, 0).ToString();
            
            if (_id.Contains("DOC"))
            {
                _newAssembly = Assembly.LoadFrom(Application.StartupPath + "\\FileSearch.dll");
                _type = _newAssembly.GetType("EchoSystems.DIIA.FileSearch.Views.ViewFile");

                Type[] _param = { typeof(System.String) };
                ConstructorInfo _ci = _type.GetConstructor(_param);
                object[] _oParamVal = { _id };

                Form _vf = _ci.Invoke(_oParamVal) as Form;
                _vf.ShowDialog();
            }
            else if (_id.Contains("IMG"))
            {
                _newAssembly = Assembly.LoadFrom(Application.StartupPath + "\\FileSearch.dll");
                _type = _newAssembly.GetType("EchoSystems.DIIA.FileSearch.Views.ViewImage");

                Type[] _param = { typeof(System.String) };
                ConstructorInfo _ci = _type.GetConstructor(_param);
                object[] _oParamVal = { _id };

                Form _vi = _ci.Invoke(_oParamVal) as Form;
                _vi.ShowDialog();
            }
        }
    }
}
