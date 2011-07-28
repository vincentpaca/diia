using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;

using EchoSystems.Common.Global;

namespace EchoSystems.Administration.Data_Access_Objects
{
    class RoleDAO
    {
        private string lRoleName;
        private string lDescription;

        private void loadAttributes(object pRole)
        {
            try
            {
                lRoleName = pRole.GetType().GetProperty("RoleName").GetValue(pRole, null).ToString();
                lDescription = pRole.GetType().GetProperty("Description").GetValue(pRole, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        public DataTable getRoles()
        {
            DataTable _dt = new DataTable();
            try
            {
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoles()", GlobalVariables.goMySqlConnection);
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

        public bool insert(object pRole)
        {
            try
            {
                loadAttributes(pRole);
                MySqlCommand _insert = new MySqlCommand("call spInsertRole('" +
                                                    lRoleName + "','" +
                                                    lDescription + "','" +
                                                    GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
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

        public bool update(object pRole)
        {
            try
            {
                loadAttributes(pRole);
                MySqlCommand _insert = new MySqlCommand("call spUpdateRole('" +
                                                    lRoleName + "','" +
                                                    lDescription + "','" +
                                                    GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
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

        public DataTable getRole(string pRoleName)
        {
            DataTable _dt = new DataTable();
            try
            {
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRole('" +
                                                                pRoleName  + "')", GlobalVariables.goMySqlConnection);
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

        public bool delete(string pRoleName)
        {
            try
            {
                MySqlCommand _delete = new MySqlCommand("call spDeleteRole('" +
                                                        pRoleName + "','" +
                                                        GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    int _rowsAffected;
                    _rowsAffected = _delete.ExecuteNonQuery();
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
                    _delete.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : " + this.ToString() + "." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }
    }
}
