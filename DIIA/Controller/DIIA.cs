using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using EchoSystems.Administration.Models;
using System.IO;
using System.Configuration;
using EchoSystems.Common.Global;
namespace EchoSystems.DIIA.Controller
{
    public class DIIA
    {
        DataTable loMenus;
        public bool isUserRoleMenu(string pMenuName)
        {
            SystemRole _systemRole = new SystemRole();
            if (loMenus == null)
                loMenus = _systemRole.getUserRoleMenus();
            DataView _dv = loMenus.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = "menu = '" + pMenuName + "'";

            if (_dv.Count > 0)
                return true;
            return false;
        }
        DataTable loForms;
        public bool isAllowedToViewUI(Form pForm)
        {
            SystemRole _systemRole = new SystemRole();
            if (loForms == null)
                loForms = _systemRole.getUserRoleForms();

            string _formName = pForm.Name;
            string _moduleName = pForm.GetType().Assembly.GetName(true).Name;

            DataView _dv = loForms.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = "Form = '" + _formName + "' and Module = '" + _moduleName + "' and Button = ''";

            if (_dv.Count > 0)
            {
                int _visible = int.Parse(_dv[0]["Visible"].ToString());
                if (_visible == 1)
                {
                    showUIButtons(pForm, _moduleName, _formName);
                    return true;
                }
            }
            return false;
        }
        private void showUIButtons(Form pForm, string pModuleName, string pFormName)
        {
            DataView _dv = loForms.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = "Form = '" + pFormName + "' and Module = '" + pModuleName + "' and Visible = 0";

            foreach (DataRowView _dRow in _dv)
            {
                hideButton((Control)pForm, _dRow["Button"].ToString());
            }
        }

        private void hideButton(Control pControl, string _controlToHide)
        {
            foreach (Control _myControl in pControl.Controls)
            {
                if (_myControl is Button)
                {
                    if (_myControl.Name == _controlToHide)
                    {
                        pControl.Controls.Remove(_myControl);
                    }
                }
                else if (_myControl is Panel ||
                    _myControl is GroupBox ||
                    _myControl is TabControl ||
                    _myControl is FlowLayoutPanel)
                {
                    hideButton(_myControl, _controlToHide);
                }
            }

        }

        public void backup()
        {
            try
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "C:\\Program Files\\MySQL\\MySQL Server 5.1\\bin\\mysqldump.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.Arguments = "-h localhost --user=root --password=" + GlobalVariables.gPassword + " --databases diia --routines --result-file \"" + GlobalVariables.goBackup + "database\\diia" + string.Format("{0:MMddyyyy}", DateTime.Now) + ".sql" + "\"";
                myProcess.Start();
                string output = myProcess.StandardOutput.ReadToEnd();

                //files
                string[] _files = Directory.GetFiles(GlobalVariables.goFileServer);
                foreach (string _file in _files)
                {
                    string[] _path = _file.Split('\\');
                    File.Copy(_file, GlobalVariables.goBackup + "repository\\" + _path[4], true);
                }

                //images
                string[] _images = Directory.GetFiles(GlobalVariables.goImageServer);
                foreach (string _image in _images)
                {
                    string[] _path = _image.Split('\\');
                    File.Copy(_image, GlobalVariables.goBackup + "images\\" + _path[4], true);
                }

                MessageBox.Show("Backup Successfull!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem backing up. Make sure that this is the server\r\n\r\n" + ex.Message, "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
