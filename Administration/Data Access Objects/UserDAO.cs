using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.Common.Global;
using MySql.Data.MySqlClient;
using System.Data;
namespace EchoSystems.Administration.Data_Access_Objects
{
    public class UserDAO
    {
        MySqlCommand loMySqlCommand;
        MySqlDataAdapter loMySqlDataAdapter;

        string lUserId;
        string lPassword;
        string lDefaultSection;

        object loUser;

        private void loadAttributes()
        {
            try
            {
                lUserId = loUser.GetType().GetProperty("userID").GetValue(loUser, null).ToString();
            }
            catch { }
            lPassword = loUser.GetType().GetProperty("password").GetValue(loUser, null).ToString();
            lDefaultSection = loUser.GetType().GetProperty("defaultSection").GetValue(loUser, null).ToString();
        }

        public void insert(object poUser, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loUser = poUser;
                loadAttributes();

                string _sql = "call spInsertUser('" + lUserId + "','" + lPassword + "','" + lDefaultSection + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                loMySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void delete(string pUserId)
        {
            try
            {
                string _sql = "call spDeleteUser('" + pUserId + "','" + GlobalVariables.goLoggedInUser + "')";

                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
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

        public void update(object poUser, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loUser = poUser;
                loadAttributes();

                string _sql = "call spUpdateUser('" + lUserId + "','" + lPassword + "','" + lDefaultSection + "','" + GlobalVariables.goLoggedInUser + "')";
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

        public DataTable get()
        {
            try
            {
                string _sql = "call spGetUsers()";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                DataTable _dt = new DataTable();
                loMySqlDataAdapter.Fill(_dt);
                return _dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySqlDataAdapter.Dispose();
            }
        }

        public DataTable getDetailsByID(string pUserId)
        {
            try
            {
                string _sql = "call spGetUserDetailsById('" + pUserId + "')";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                DataTable _dt = new DataTable();
                loMySqlDataAdapter.Fill(_dt);
                return _dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySqlDataAdapter.Dispose();
            }
        }

        public DataTable getSections()
        {
            try
            {
                loMySqlDataAdapter = new MySqlDataAdapter("call spGetAllSections()", GlobalVariables.goMySqlConnection);
                DataTable _dt = new DataTable();
                loMySqlDataAdapter.Fill(_dt);
                return _dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySqlDataAdapter.Dispose();
            }
        }
    }
}
