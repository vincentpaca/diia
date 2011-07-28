using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.Common.Global;
using MySql.Data.MySqlClient;

namespace EchoSystems.Administration.Data_Access_Objects
{
    public class UserRoleDAO
    {
        MySqlCommand loMySqlCommand;

        string lUserId;
        string lRoleName;

        object loUserRole;

        private void loadAttributes()
        {
            lUserId = loUserRole.GetType().GetProperty("UserId").GetValue(loUserRole, null).ToString();
            lRoleName = loUserRole.GetType().GetProperty("RoleName").GetValue(loUserRole, null).ToString();
        }

        public void insert(object poUserRole, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loUserRole = poUserRole;
                loadAttributes();

                string _sql = "call spInsertUserRole('" + lUserId + "','" + lRoleName + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                loMySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySqlCommand.Dispose();
            }
        }

        public void update(object poUserRole, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loUserRole = poUserRole;
                loadAttributes();

                string _sql = "call spUpdateUserRole('" + lUserId + "','" + lRoleName + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                loMySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySqlCommand.Dispose();
            }
        }
    }
}
