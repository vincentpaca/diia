using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

using EchoSystems.Administration.Views;
using EchoSystems.Common.Global;
using EchoSystems.DIIA.FileManager.Views;
using EchoSystems.DIIA.FileSearch.Views;
using EchoSystems.Common.Views;
using EchoSystems.DIIA.Configuration.Views;

using MySql.Data.MySqlClient;
namespace EchoSystems.DIIA.Views
{
    public partial class MainMDI : Form
    {
        private Controller.DIIA loDIIA;
        private ModuleRegistry loModuleRegistry;

        public MainMDI()
        {
            InitializeComponent();
            loDIIA = new Controller.DIIA();
            loModuleRegistry = new ModuleRegistry();

            foreach (Control _ctrl in this.Controls)
            {
                if (_ctrl is MdiClient)
                {
                    _ctrl.BackgroundImage = Properties.Resources.freeman;
                    _ctrl.BackgroundImageLayout = ImageLayout.Center;
                    _ctrl.BackColor = Color.Gray;
                }
            }
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            //set the MDI
            GlobalVariables.goMainMDI = this;
            //show the splash screen and load the database connection
            SplashScreen _splashScreen = new SplashScreen();
            _splashScreen.ShowDialog(this);
            //login
            LoginUI _loginUI = new LoginUI();
            _loginUI.ShowDialog(this);

            if (GlobalVariables.goLoggedInUser != null)
            {
                setDisableMenuItems();
                setUserMenus();
                loadDll();

                tsslLoggedInUser.Text = tsslLoggedInUser.Text + " " + GlobalVariables.goLoggedInUser;
                tsslLogTime.Text = DateTime.Now.ToString();
            }
        }

        public void updateStatus(string pStatus)
        {
            this.tsslStatus.Text = "Status: " + pStatus.ToString();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchUI _searchUI = Application.OpenForms["SearchUI"] as SearchUI;
            if (_searchUI != null)
            {
                if (_searchUI.WindowState == FormWindowState.Minimized)
                {
                    _searchUI.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    _searchUI.Activate();
                    _searchUI.BringToFront();
                }
            }
            else
            {
                _searchUI = new SearchUI();
                _searchUI.MdiParent = this;
                _searchUI.Show();
                _searchUI.WindowState = FormWindowState.Maximized;
            }
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileUpload _fileUpload = Application.OpenForms["FileUpload"] as FileUpload;
            if (_fileUpload != null)
            {
                if (_fileUpload.WindowState == FormWindowState.Minimized)
                {
                    _fileUpload.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _fileUpload.Activate();
                    _fileUpload.BringToFront();
                }
            }
            else
            {
                _fileUpload = new FileUpload();
                _fileUpload.MdiParent = this;
                _fileUpload.WindowState = FormWindowState.Maximized;
                _fileUpload.Show();
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageUpload _imageUpload = Application.OpenForms["ImageUpload"] as ImageUpload;
            if (_imageUpload != null)
            {
                if (_imageUpload.WindowState == FormWindowState.Minimized)
                {
                    _imageUpload.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _imageUpload.Activate();
                    _imageUpload.BringToFront();
                }
            }
            else
            {
                _imageUpload = new ImageUpload();
                _imageUpload.MdiParent = this;
                _imageUpload.WindowState = FormWindowState.Maximized;
                _imageUpload.Show();
            }
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMasterList _employeeMasterList = Application.OpenForms["EmployeeMasterList"] as EmployeeMasterList;
            if (_employeeMasterList != null)
            {
                if (_employeeMasterList.WindowState == FormWindowState.Minimized)
                {
                    _employeeMasterList.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _employeeMasterList.Activate();
                    _employeeMasterList.BringToFront();
                }
            }
            else
            {
                _employeeMasterList = new EmployeeMasterList();
                _employeeMasterList.MdiParent = this;
                _employeeMasterList.WindowState = FormWindowState.Maximized;
                _employeeMasterList.Show();
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesMasterList _roleMasterList = Application.OpenForms["RolesMasterList"] as RolesMasterList;
            if (_roleMasterList != null)
            {
                if (_roleMasterList.WindowState == FormWindowState.Minimized)
                {
                    _roleMasterList.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _roleMasterList.Activate();
                    _roleMasterList.BringToFront();
                }
            }
            else
            {
                _roleMasterList = new RolesMasterList();
                _roleMasterList.MdiParent = this;
                _roleMasterList.WindowState = FormWindowState.Maximized;
                _roleMasterList.Show();
            }
        }

        private void loadDll()
        {
            string[] _dlls = GlobalVariables.goAppDLL.Split(',');
            foreach (string _dll in _dlls)
            {
                loModuleRegistry.RegisterModuleTypes(_dll);
                try
                {
                    string[] _name = _dll.Split('.');
                    //show mnu for extra dll
                    try
                    {
                        ToolStripMenuItem _config = (ToolStripMenuItem)this.msMain.Items["tsmConfiguration"];
                        _config.DropDownItems["mnu" + _name[0]].Visible = true;
                    }
                    catch { }
                    try
                    {
                        ToolStripMenuItem _config = (ToolStripMenuItem)this.msMain.Items["tsm" + _name[0]];
                        _config.Visible = true;
                    }
                    catch { }
                }
                catch
                {
                }
            }
        }

        private void setDisableMenuItems()
        {
            ToolStripItem ctrl;

            foreach (ToolStripItem tempLoopVar_ctrl in this.msMain.Items)
            {
                ctrl = tempLoopVar_ctrl;
                ctrl.Enabled = false;
                if (((ToolStripMenuItem)ctrl).HasDropDownItems)
                {
                    foreach (ToolStripItem drop in ((ToolStripMenuItem)ctrl).DropDownItems)
                    {
                        drop.Enabled = false;

                        if (drop.GetType() != typeof(ToolStripSeparator))
                        {
                            if (((ToolStripMenuItem)drop).HasDropDownItems)
                            {
                                foreach (ToolStripItem drop_1 in ((ToolStripMenuItem)drop).DropDownItems)
                                {
                                    drop_1.Enabled = false;
                                }
                            }
                        }

                    }
                }
            }
        }

        private void setUserMenus()
        {
            setDisableMenuItems();
            ToolStripItem ctrl;
            foreach (ToolStripItem tempLoopVar_ctrl in this.msMain.Items)
            {
                ctrl = tempLoopVar_ctrl;
                string str = ctrl.Text.Replace("&", "");

                if (loDIIA.isUserRoleMenu(str))
                {
                    ctrl.Enabled = true;
                }


                if (((ToolStripMenuItem)ctrl).HasDropDownItems)
                {
                    foreach (ToolStripItem drop in ((ToolStripMenuItem)ctrl).DropDownItems)
                    {


                        string str_1 = drop.Text.Replace("&", "");
                        if (loDIIA.isUserRoleMenu(str_1))
                        {
                            drop.Enabled = true;
                        }
                        if (drop.GetType() != typeof(ToolStripSeparator))
                        {
                            if (((ToolStripMenuItem)drop).HasDropDownItems)
                            {
                                foreach (ToolStripItem drop_1 in ((ToolStripMenuItem)drop).DropDownItems)
                                {

                                    string str_2 = drop_1.Text.Replace("&", "");
                                    if (loDIIA.isUserRoleMenu(str_2))
                                    {
                                        drop_1.Enabled = true;
                                    }


                                }
                            }
                        }

                    }
                }
            }

        }

        private void MainMDI_MdiChildActivate(object sender, EventArgs e)
        {
            Form child = null;
            try
            {
                child = this.MdiChildren[this.MdiChildren.Length - 1];
            }
            catch
            {
            }

            if (!loDIIA.isAllowedToViewUI(child))
            {
                child.Paint += new PaintEventHandler(child_Paint);
            }
        }

        internal void child_Paint(object sender, PaintEventArgs e)
        {
            Form _childForm = (Form)sender;
            _childForm.Close();
        }

        private void systemRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemRoleUI _roleUI = Application.OpenForms["SystemRoleUI"] as SystemRoleUI;
            if (_roleUI != null)
            {
                if (_roleUI.WindowState == FormWindowState.Minimized)
                {
                    _roleUI.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _roleUI.Activate();
                    _roleUI.BringToFront();
                }
            }
            else
            {
                _roleUI = new SystemRoleUI();
                _roleUI.MdiParent = this;
                _roleUI.WindowState = FormWindowState.Maximized;
                _roleUI.Show();
            }
        }

        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //atay hasul ning word

                Object _missing = (Object)Type.Missing;

                if (GlobalVariables.goMySqlConnection.State == ConnectionState.Open)
                {
                    GlobalVariables.goMySqlConnection.Close();
                }

                GlobalVariables.goDocument.Close(_missing, _missing, _missing);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(GlobalVariables.goDocument);
                GlobalVariables.goDocument = null;
                GlobalVariables.goApplication.Quit(_missing, _missing, _missing);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(GlobalVariables.goApplication);
                GlobalVariables.goApplication = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }

        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logs _logUI = Application.OpenForms["Logs"] as Logs;
            if (_logUI != null)
            {
                if (_logUI.WindowState == FormWindowState.Minimized)
                {
                    _logUI.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    _logUI.Activate();
                    _logUI.BringToFront();
                }
            }
            else
            {
                _logUI = new Logs();
                _logUI.MdiParent = this;
                _logUI.Show();
                _logUI.WindowState = FormWindowState.Maximized;
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMasterList _roleUI = Application.OpenForms["UserMasterList"] as UserMasterList;
            if (_roleUI != null)
            {
                if (_roleUI.WindowState == FormWindowState.Minimized)
                {
                    _roleUI.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _roleUI.Activate();
                    _roleUI.BringToFront();
                }
            }
            else
            {
                _roleUI = new UserMasterList();
                _roleUI.MdiParent = this;
                _roleUI.WindowState = FormWindowState.Maximized;
                _roleUI.Show();
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutUs _about = new AboutUs();
            _about.ShowDialog(this);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loDIIA.backup();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileUpload _fileUpload = Application.OpenForms["FileUpload"] as FileUpload;
            if (_fileUpload != null)
            {
                if (_fileUpload.WindowState == FormWindowState.Minimized)
                {
                    _fileUpload.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _fileUpload.Activate();
                    _fileUpload.BringToFront();
                }
            }
            else
            {
                _fileUpload = new FileUpload();
                _fileUpload.MdiParent = this;
                _fileUpload.WindowState = FormWindowState.Maximized;
                _fileUpload.Show();
            }
        }

        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageUpload _imageUpload = Application.OpenForms["ImageUpload"] as ImageUpload;
            if (_imageUpload != null)
            {
                if (_imageUpload.WindowState == FormWindowState.Minimized)
                {
                    _imageUpload.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _imageUpload.Activate();
                    _imageUpload.BringToFront();
                }
            }
            else
            {
                _imageUpload = new ImageUpload();
                _imageUpload.MdiParent = this;
                _imageUpload.WindowState = FormWindowState.Maximized;
                _imageUpload.Show();
            }
        }
    }
}
