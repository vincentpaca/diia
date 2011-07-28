using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.Configuration.Data_Access_Objects
{
    public class EmployeeTypeDAO
    {
        MySqlDataAdapter loMySqlDataAdapter;
        DataTable loDataTable;

        public DataTable get()
        {
            try
            {
                string _sql = "call spGetEmployeeTypes()";
                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable("EmployeeTypes");
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
    }
}
