using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.Administration.Data_Access_Objects
{
    public class LoginDetailsDAO
    {
        string lUsername;
        string lPassword;

        object loLoginDetails;

        MySqlCommand loMySqlCommand;

        public void loadAttributes(object loLoginDetails)
        {
            try
            {
                lUsername = loLoginDetails.GetType().GetProperty("Username").GetValue(loLoginDetails, null).ToString();
                lPassword = loLoginDetails.GetType().GetProperty("Password").GetValue(loLoginDetails, null).ToString();
            }
            catch (Exception)
            {
               throw;
            }
            
        }

        public string loginUser(object poLoginDetails)
        {
            try
            {
                loLoginDetails = poLoginDetails;
                loadAttributes(poLoginDetails);
                string _sql = "call spLoginUser('" + lUsername + "','" + lPassword + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                string _username = loMySqlCommand.ExecuteScalar().ToString();
                return _username;
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
