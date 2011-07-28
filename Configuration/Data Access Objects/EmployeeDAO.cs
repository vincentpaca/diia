using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.Configuration.Data_Access_Objects
{
    public class EmployeeDAO
    {
        MySqlDataAdapter loMySqlDataAdapter;
        MySqlCommand loMySqlCommand;
        DataTable loDataTable;

        object loEmployee;

        string lFirstName;
        string lLastName;
        string lMiddleName;
        string lEmployeeType;
        string lInitials;
        string lEmployeeId;

        //by using reflection, we 
        private void loadAttributes()
        {
            lFirstName = loEmployee.GetType().GetProperty("FirstName").GetValue(loEmployee, null).ToString();
            lLastName = loEmployee.GetType().GetProperty("LastName").GetValue(loEmployee, null).ToString();
            lMiddleName = loEmployee.GetType().GetProperty("MiddleName").GetValue(loEmployee, null).ToString();
            lEmployeeType = loEmployee.GetType().GetProperty("EmployeeType").GetValue(loEmployee, null).ToString();
            lInitials = loEmployee.GetType().GetProperty("Initials").GetValue(loEmployee, null).ToString();
            try
            {
                lEmployeeId = loEmployee.GetType().GetProperty("EmployeeId").GetValue(loEmployee, null).ToString();
            }
            catch { }
        }

        public DataTable getByType(string pType)
        {
            try
            {
                string _sql = "call spGetEmployeesByType('" + pType + "')";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable(pType + " Employees");
                loMySqlDataAdapter.Fill(loDataTable);
                return loDataTable;
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

        public DataTable getDetailsByID(string pEmployeeId)
        {
            try
            {
                string _sql = "call spGetEmployeeDetailsByID('" + pEmployeeId + "')";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable("EmployeeDetails");
                loMySqlDataAdapter.Fill(loDataTable);
                return loDataTable;
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

        public bool delete(string pEmployeeId)
        {
            try
            {
                MySqlCommand _delete = new MySqlCommand("call spDeleteEmployee('" + pEmployeeId + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    int _rowsAffected = _delete.ExecuteNonQuery();
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
                throw ex;
            }
        }

        public DataTable get()
        {
            try
            {
                string _sql = "call spGetEmployees()";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable("Employees");
                loMySqlDataAdapter.Fill(loDataTable);
                return loDataTable;
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

        public string insert(object poEmployee)
        {
            try
            {
                loEmployee = poEmployee;
                loadAttributes();

                string _sql = "call spInsertEmployee('" + lFirstName + "','" + lMiddleName + "','" + lLastName + "','" + lInitials + "','" + lEmployeeType + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                return loMySqlCommand.ExecuteScalar().ToString();
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

        public void update(object poEmployee)
        {
            try
            {
                loEmployee = poEmployee;
                loadAttributes();

                string _sql = "call spUpdateEmployee('" + lEmployeeId +"','" + lFirstName + "','" + lMiddleName + "','" + lLastName + "','" + lInitials + "','" + lEmployeeType + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
