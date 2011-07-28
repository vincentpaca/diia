using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.Configuration.Data_Access_Objects
{
    public class NewspaperDAO
    {
        MySqlDataAdapter loMySqlDataAdapter;
        DataTable loDataTable;

        public DataTable get()
        {
            try
            {
                string _sql = "call spGetNewspapers()";

                loMySqlDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable("Newspapers");
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
