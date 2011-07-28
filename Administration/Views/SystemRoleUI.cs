using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EchoSystems.Common.Global;
using EchoSystems.Administration.Controller;

namespace EchoSystems.Administration.Views
{
    public partial class SystemRoleUI : Form
    {
        Controller.Administration loAdministration;
        public SystemRoleUI()
        {
            loAdministration = new Controller.Administration();
            InitializeComponent();
        }

        private void SystemRoleUI_Load(object sender, EventArgs e)
        {
            loadRoles();
            loadMenus();
            loadRoleMenus();
            loadForms();
            loadRoleForms();
            loadPrivileges();
            loadRolePrivileges();
        }

        private void loadMenus()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref grdMenus, loAdministration.getSystemMenus());
        }

        private void loadForms()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref grdForms, loAdministration.getSystemForms());
        }

        private void loadPrivileges()
        {
            GlobalFunctions.bindDataTableToFlexGrid(ref grdPrivileges, loAdministration.getSystemPrivileges());
        }

        public void loadRoles()
        {
            cboRoleName.DataSource = loAdministration.getRoles();
            cboRoleName.DisplayMember = "RoleName";
        }

        private void grdMenus_SelChange(object sender, EventArgs e)
        {
            if (grdMenus.Col > 2)
            {
                grdMenus.AllowEditing = true;
            }
            else
            {
                grdMenus.AllowEditing = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView _dRow = (DataRowView)cboRoleName.SelectedItem;
            txtDescription.Text = _dRow["Description"].ToString();

            loadRoleMenus();
            loadRoleForms();
            loadRolePrivileges();
        }

        private void loadRoleMenus()
        {
            DataTable _tableMenus = loAdministration.getRoleMenus(cboRoleName.Text);

            //uncheck all
            for (int _row = 1; _row < this.grdMenus.Rows.Count; _row++)
            {
                this.grdMenus.SetData(_row, 3, false);
            }


            for (int _row = 1; _row < this.grdMenus.Rows.Count; _row++)
            {
                for (int _col = 0; _col < this.grdMenus.Cols.Count - 1; _col++)
                {
                    foreach (DataRow _dRow in _tableMenus.Rows)
                    {
                        string _str = this.grdMenus.GetDataDisplay(_row, _col);

                        string _menuName = _dRow["Menu"].ToString();
                        string _enable = _dRow["Enable"].ToString();

                        if (_str == _menuName && _enable == "1")
                        {
                            this.grdMenus.SetData(_row, 3, true);
                            break;

                        }// end if

                    }// end inner for

                }// end for

            }//end for

        }

        private void loadRoleForms()
        {
            DataTable _tableForms = loAdministration.getRoleForms(cboRoleName.Text);

            for (int _row = 1; _row < this.grdForms.Rows.Count; _row++)
            {
                this.grdForms.SetData(_row, 3, false);
            }


            foreach (DataRow _dRow in _tableForms.Rows)
            {
                int _visible = int.Parse(_dRow["Visible"].ToString());

                if (_visible == 1)
                {
                    string _module = _dRow["Module"].ToString();
                    string _formName = _dRow["Form"].ToString();
                    string _buttonName = _dRow["Button"].ToString();

                    for (int _row = 1; _row < this.grdForms.Rows.Count; _row++)
                    {

                        string _strModule = "";
                        string _strFormName = "";
                        string _strButton = "";

                        _strModule = this.grdForms.GetDataDisplay(_row, 4);
                        _strFormName = this.grdForms.GetDataDisplay(_row, 5);
                        _strButton = this.grdForms.GetDataDisplay(_row, 6);

                        if (_strModule.ToUpper() == _module.ToUpper() &&
                            _strFormName.ToUpper() == _formName.ToUpper() &&
                            _strButton.ToUpper() == _buttonName.ToUpper())
                        {
                            this.grdForms.SetData(_row, 3, true);
                            break;
                        }

                    }// end inner for
                }

            }//end for
        }

        private void loadRolePrivileges()
        {
            DataTable _privileges = loAdministration.getRolePrivileges(cboRoleName.Text);

            for (int i = 1; i < this.grdPrivileges.Rows.Count; i++)
            {
                this.grdPrivileges.SetData(i, 1, false);
            }

            foreach (DataRow _dRow in _privileges.Rows)
            {
                int _allowed = int.Parse(_dRow["Allowed"].ToString());
                string _privilege = _dRow["Privilege"].ToString();
                if (_allowed == 1)
                {
                    for (int _row = 1; _row < this.grdPrivileges.Rows.Count; _row++)
                    {
                        if (_privilege == grdPrivileges.GetDataDisplay(_row, 0))
                        {
                            this.grdPrivileges.SetData(_row, 1, true);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (loAdministration.saveSystemRole(GlobalFunctions.convertFlexGridToDataTable(grdMenus), GlobalFunctions.convertFlexGridToDataTable(grdForms), GlobalFunctions.convertFlexGridToDataTable(grdPrivileges), cboRoleName.Text))
            {
                MessageBox.Show("Effects will take effect after log-off.", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("There was a problem on saving one of the roles.", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void grdForms_SelChange(object sender, EventArgs e)
        {
            if (grdForms.Col > 2)
            {
                grdForms.AllowEditing = true;
            }
            else
            {
                grdForms.AllowEditing = false;
            }
        }

        private void grdPrivileges_SelChange(object sender, EventArgs e)
        {
            if (grdPrivileges.Col > 0)
            {  
                grdPrivileges.AllowEditing = true;
            }
            else
            {
                grdPrivileges.AllowEditing = false;
            }
        }
    }
}
