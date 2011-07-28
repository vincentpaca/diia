using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.Administration.Data_Access_Objects
{
    public class SystemRoleDAO
    {
        public DataTable getRoleMenus(string pRoleName)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoleMenus('" + pRoleName + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool insertMenu(string pRoleName, string pMenu, bool pEnable, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _insert = new MySqlCommand("call spInsertRoleMenus('" + pRoleName + "','" + pMenu + "'," + pEnable +  ",'" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _insert.Transaction = pTrans;
                    int _rowsAffected = _insert.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _insert.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool updateMenu(string pRoleName, string pMenu, bool pEnable, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _update = new MySqlCommand("call spUpdateRoleMenus('" + pRoleName + "','" + pMenu + "'," + pEnable + ",'"  + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _update.Transaction = pTrans;
                    int _rowsAffected = _update.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _update.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getUserRoleMenus()
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetUserRoleMenus('" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool insertForm(string pRoleName, string pModule, string pForm, string pButton, bool pVisible, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _insert = new MySqlCommand("call spInsertRoleForms('" + pRoleName + "','"
                                                                                    + pModule + "','"
                                                                                    + pForm + "','"
                                                                                    + pButton + "',"
                                                                                    + pVisible + ",'"
                                                                                    + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _insert.Transaction = pTrans;
                    int _rowsAffected = _insert.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _insert.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool updateForm(string pRoleName, string pModule, string pForm, string pButton, bool pVisible, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _update = new MySqlCommand("call spUpdateRoleForms('" + pRoleName + "','"
                                                                                    + pModule + "','"
                                                                                    + pForm + "','"
                                                                                    + pButton + "',"
                                                                                    + pVisible + ",'"
                                                                                    + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _update.Transaction = pTrans;
                    int _rowsAffected = _update.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _update.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getRoleForms(string pRoleName)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoleForms('" + pRoleName + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getUserRoleForms()
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetUserRoleForms('" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getSystemPrivileges()
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetSystemPrivileges()", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool insertPrivilege(string pRoleName, string pPrivilege, bool pAllowed, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _insert = new MySqlCommand("call spInsertRolePrivileges('" + pRoleName + "','" + pPrivilege + "'," + pAllowed + ",'" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _insert.Transaction = pTrans;
                    int _rowsAffected = _insert.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _insert.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public bool updatePrivilege(string pRoleName, string pPrivilege, bool pAllowed, MySqlTransaction pTrans)
        {
            try
            {
                MySqlCommand _update = new MySqlCommand("call spUpdateRolePrivileges('" + pRoleName + "','" + pPrivilege + "'," + pAllowed + ",'" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _update.Transaction = pTrans;
                    int _rowsAffected = _update.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _update.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getRolePrivileges(string pRoleName)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRolePrivileges('" + pRoleName + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getUserRolePrivileges()
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetUserRolePrivileges('" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }
    }
}
