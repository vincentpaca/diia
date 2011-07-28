using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EchoSystems.Administration.Models;
using EchoSystems.Common.Global;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace EchoSystems.Administration.Controller
{
    public class Administration
    {
        LoginDetails loLoginDetails;
        User loUser;
        UserRole loUserRole;

        MySqlTransaction loMySqlTransaction;

        public bool loginUser(string pUsername, string pPassword)
        {
            loLoginDetails = new LoginDetails();
            loLoginDetails.Username = pUsername;
            loLoginDetails.Password = pPassword;

            string _username = loLoginDetails.loginUser();

            if (_username != "" || _username != null)
            {
                GlobalVariables.goLoggedInUser = _username;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void openSQLConnection()
        {
            try
            {
                string _connStr = ConfigurationManager.AppSettings["SqlConnection"];
                GlobalVariables.goMySqlConnection = new MySqlConnection(_connStr);
                GlobalVariables.goMySqlConnection.Open();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void connectToFileServer()
        {
            try
            {
                string _fileSvr = ConfigurationManager.AppSettings["FileServer"];
                GlobalVariables.goFileServer = _fileSvr;
                string _recyclebin = ConfigurationManager.AppSettings["RecycleBin"];
                GlobalVariables.goRecycleBin = _recyclebin;
                string _backup = ConfigurationManager.AppSettings["BackupPath"];
                GlobalVariables.goBackup = _backup;
                string _password = ConfigurationManager.AppSettings["Password"];
                GlobalVariables.gPassword = _password;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void connectToImageServer()
        {
            try
            {
                string _imageSvr = ConfigurationManager.AppSettings["ImageServer"];
                GlobalVariables.goImageServer = _imageSvr;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void loadDLLs()
        {
            try
            {
                string _dlls = ConfigurationManager.AppSettings["AppDLLs"];
                GlobalVariables.goAppDLL = _dlls;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region USER

        public void insertUser(string pUserId, string pPassword, string pRole, string pSection)
        {
            try
            {
                loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();

                loUser = new User();
                loUser.userID = pUserId;
                loUser.password = pPassword;
                loUser.defaultSection = pSection;
                loUser.insert(ref loMySqlTransaction);

                loUserRole = new UserRole();
                loUserRole.RoleName = pRole;
                loUserRole.UserId = pUserId;
                loUserRole.insert(ref loMySqlTransaction);

                loMySqlTransaction.Commit();
            }
            catch (Exception)
            {
                loMySqlTransaction.Rollback();
                throw;
            }
        }

        public void updateUser(string pUserId, string pPassword, string pRole, string pSection)
        {
            try
            {
                loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();

                loUser = new User();
                loUser.userID = pUserId;
                loUser.password = pPassword;
                loUser.defaultSection = pSection;
                loUser.update(ref loMySqlTransaction);

                loUserRole = new UserRole();
                loUserRole.RoleName = pRole;
                loUserRole.UserId = pUserId;
                loUserRole.insert(ref loMySqlTransaction);

                loMySqlTransaction.Commit();
            }
            catch (Exception)
            {
                loMySqlTransaction.Rollback();
                throw;
            }
        }

        public User getUserDetailsById(string pUserId)
        {
            loUser = new User(pUserId);
            return loUser;
        }

        public DataTable getUsers()
        {
            loUser = new User();
            return loUser.get();
        }

        public void deleteUser(string pUserId)
        {
            loUser = new User();
            loUser.delete(pUserId);
        }

        #endregion

        #region "ROLESUI"
        public DataTable getRoles()
        {
            Role _role = new Role();
            return _role.getRoles();
        }

        public Role getRole(string pRoleName)
        {
            Role _role = new Role(pRoleName);
            return _role;
        }

        public void saveRole(string pRoleName, string pDescription)
        {
            Role _role = new Role();
            _role.RoleName = pRoleName;
            _role.Description = pDescription;
            _role.insert();
        }

        public void updateRole(string pRoleName, string pDescription)
        {
            Role _role = new Role();
            _role.RoleName = pRoleName;
            _role.Description = pDescription;
            _role.update();
        }

        public bool deleteRole(string pRoleName)
        {
            Role _role = new Role(pRoleName);
            return _role.delete();
        }

        #endregion

        #region "SYSTEMROLEUI"
        public DataTable getSystemMenus()
        {
            Form frm = (Form)GlobalVariables.goMainMDI;
            MenuStrip mainMenu = frm.MainMenuStrip;

            DataTable _systemMenus = new DataTable();
            _systemMenus.Columns.Add("MainMenu", typeof(string));
            _systemMenus.Columns.Add("SubMenu", typeof(string));
            _systemMenus.Columns.Add("Menu", typeof(string));
            DataRow _dRow;

            foreach (ToolStripMenuItem mnu in mainMenu.Items)
            {
                if (mnu.Text != "")
                {
                    _dRow = _systemMenus.NewRow();
                    _dRow["MainMenu"] = mnu.Text.Replace("&", "");
                    _systemMenus.Rows.Add(_dRow);

                    if (mnu.HasDropDownItems)
                    {
                        foreach (ToolStripItem subMenu in mnu.DropDownItems)
                        {
                            if (subMenu.Text != "")
                            {
                                _dRow = _systemMenus.NewRow();
                                _dRow["SubMenu"] = subMenu.Text.Replace("&", "");
                                _systemMenus.Rows.Add(_dRow);

                                if (subMenu.GetType() != typeof(ToolStripSeparator))
                                {
                                    ToolStripMenuItem _temp = (ToolStripMenuItem)subMenu;
                                    if (_temp.HasDropDownItems)
                                    {
                                        foreach (ToolStripItem subSubMenu in _temp.DropDownItems)
                                        {
                                            if (subSubMenu.Text != "")
                                            {
                                                _dRow = _systemMenus.NewRow();
                                                _dRow["Menu"] = subSubMenu.Text.Replace("&", "");
                                                _systemMenus.Rows.Add(_dRow);
                                            } // endif
                                        }// end foreach

                                    }//endif

                                }// endif

                            }// endif 

                        }// end foreach

                    }//end if

                }//end if

            }//end foreach

            return _systemMenus;
        }

        public DataTable getSystemForms()
        {
            string[] DLLs = GlobalVariables.goAppDLL.Split(',');
            DataTable _systemForms = new DataTable();
            _systemForms.Columns.Add("ModuleText", typeof(string));
            _systemForms.Columns.Add("FormText", typeof(string));
            _systemForms.Columns.Add("ButtonText", typeof(string));
            _systemForms.Columns.Add("Module", typeof(string));
            _systemForms.Columns.Add("Form", typeof(string));
            _systemForms.Columns.Add("Button", typeof(string));
            DataRow _dRow;

            foreach (string _moduleName in DLLs)
            {

                Assembly new_assembly;
                Type[] types;
                new_assembly = Assembly.LoadFrom(_moduleName);

                types = new_assembly.GetTypes();

                string _namespace = new_assembly.GetName(true).Name;

                _dRow = _systemForms.NewRow();
                _dRow["ModuleText"] = _namespace;
                _systemForms.Rows.Add(_dRow);

                foreach (Type type in types)
                {
                    if (!type.IsAbstract)
                    {
                        //if (type.BaseType == typeof(Form))
                        //{
                        try
                        {
                            //_dRow = _systemForms.NewRow();
                            //_dRow["Form"] = type.Name;
                            //_systemForms.Rows.Add(_dRow);

                            ConstructorInfo cInfo = type.GetConstructor(System.Type.EmptyTypes);
                            try
                            {
                                Form frm = (Form)cInfo.Invoke(null);
                                _dRow = _systemForms.NewRow();
                                _dRow["Module"] = _namespace;
                                _dRow["FormText"] = frm.Text;
                                _dRow["Form"] = frm.Name;
                                _systemForms.Rows.Add(_dRow);
                                loadFormButton((Control)frm, ref _systemForms, type.Name, _namespace);
                            }
                            catch { }
                        }
                        catch { }
                    }
                }

            }//end foreach
            return _systemForms;
        }

        public DataTable getSystemPrivileges()
        {
            SystemRole _systemRole = new SystemRole();
            return _systemRole.getSystemPrivileges();
        }

        private void loadFormButton(Control pControl, ref DataTable pSystemForms, string pFormName, string pModuleName)
        {
            DataRow _dRow;
            foreach (Control _ctrl in pControl.Controls)
            {
                if (_ctrl is Button)
                {
                    _dRow = pSystemForms.NewRow();
                    _dRow["Module"] = pModuleName;
                    _dRow["Form"] = pFormName;
                    _dRow["ButtonText"] = _ctrl.Text.Replace("&", "");
                    _dRow["Button"] = _ctrl.Name;
                    pSystemForms.Rows.Add(_dRow);
                }
                else if (_ctrl is Panel || _ctrl is GroupBox || _ctrl is TabControl)
                {
                    loadFormButton(_ctrl, ref pSystemForms, pFormName, pModuleName);
                }
            }
        }

        public DataTable getRoleMenus(string pRoleName)
        {
            SystemRole _systemRole = new SystemRole();
            return _systemRole.getRoleMenus(pRoleName);
        }

        public DataTable getRoleForms(string pRoleName)
        {
            SystemRole _systemRole = new SystemRole();
            return _systemRole.getRoleForms(pRoleName);
        }

        public DataTable getRolePrivileges(string pRoleName)
        {
            SystemRole _systemRole = new SystemRole();
            return _systemRole.getRolePrivileges(pRoleName);
        }

        public bool saveSystemRole(DataTable pMenus, DataTable pForms, DataTable pPrivileges, string pRoleName)
        {
            SystemRole _systemRole = new SystemRole();
            bool _success = false;
            string _menu = "";
            bool _enable = false;
            MySqlTransaction _trans = GlobalVariables.goMySqlConnection.BeginTransaction();
            //menus
            try
            {
                if (pMenus.Rows.Count > 0)
                {
                    foreach (DataRow _dRow in pMenus.Rows)
                    {
                        for (int _col = 0; _col < pMenus.Columns.Count - 1; _col++)
                        {
                            if (_dRow[_col].ToString() != "")
                            {
                                _menu = _dRow[_col].ToString();
                            }
                        }
                        if (_menu != "")
                        {
                            try
                            {
                                _enable = Boolean.Parse(_dRow["Enable"].ToString());
                            }
                            catch
                            {
                                _enable = false;
                            }
                            try
                            {
                                _success = _systemRole.insertMenu(pRoleName, _menu, _enable, _trans);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    _success = _systemRole.updateMenu(pRoleName, _menu, _enable, _trans);
                                }
                                else
                                {
                                    throw ex;
                                }
                            }
                        }
                        if (!_success)
                        {
                            return _success;
                        }
                    }

                    //forms

                }

                //forms
                if (pForms.Rows.Count > 0)
                {
                    string _Module = "";
                    string _Form = "";
                    string _Button = "";
                    bool _visible = false;
                    foreach (DataRow _dRow in pForms.Rows)
                    {
                        _Module = _dRow["Module"].ToString();
                        _Form = _dRow["Form"].ToString();
                        if (_Module != "" && _Form != "")
                        {
                            _Button = _dRow["Button"].ToString();
                            try
                            {
                                _visible = Boolean.Parse(_dRow["Visible"].ToString());
                            }
                            catch
                            {
                                _visible = false;
                            }
                            try
                            {
                                _success = _systemRole.insertForm(pRoleName, _Module, _Form, _Button, _visible, _trans);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    _success = _systemRole.updateForm(pRoleName, _Module, _Form, _Button, _visible, _trans);
                                }
                                else
                                {
                                    throw ex;
                                }
                            }
                        }
                    }
                }

                //privileges
                if (pPrivileges.Rows.Count > 1)
                {
                    string _privilege = "";
                    bool _allowed = false;
                    foreach (DataRow _dRow in pPrivileges.Rows)
                    {
                        _privilege = _dRow["Privilege"].ToString();
                        _allowed = false;
                        try
                        {
                            if (_privilege != "")
                            {
                                try
                                {
                                    _allowed = Boolean.Parse(_dRow["Allowed"].ToString());
                                }
                                catch
                                {
                                    _allowed = false;
                                }
                                _success = _systemRole.insertPrivilege(pRoleName, _privilege, _allowed, _trans);
                            }

                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Duplicate"))
                            {
                                _success = _systemRole.updatePrivilege(pRoleName, _privilege, _allowed, _trans);
                            }
                            else
                            {
                                throw ex;
                            }
                        }
                    }
                }
                _trans.Commit();
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                throw ex;
            }
            finally
            {
                _trans.Dispose();
            }
            return _success;
        }
        #endregion 

        #region "SECTIONS"
        public DataTable getSections()
        {
            loUser = new User();
            return loUser.getSections();
        }
        #endregion
    }
}
