using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.Configuration.Data_Access_Objects
{
    public class SectionDAO
    {
        MySqlDataAdapter loMySQLDataAdapter;
        MySqlCommand loMySqlCommand;
        DataTable loDataTable;

        public DataTable get(string pNewspaperId)
        {
            try
            {
                string _sql = "call spGetSections('" + pNewspaperId + "')";

                loMySQLDataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.goMySqlConnection);
                loDataTable = new DataTable("Sections");
                loMySQLDataAdapter.Fill(loDataTable);
                return loDataTable;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                loMySQLDataAdapter.Dispose();
            }
        }

        public string getSectionName(string pSection)
        {
            try
            {
                string _sql = "call spGetSectionName('" + pSection + "')";

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

        public string getUserDefaultSection()
        {
            try
            {
                loMySqlCommand = new MySqlCommand("call spGetUserDefaultSection('" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                return loMySqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally { loMySqlCommand.Dispose(); }
        }
    }
}
