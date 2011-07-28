using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    class DocTypeDAO
    {
        public DataTable get()
        {
            DataTable _dt = new DataTable();
            try
            {
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocTypes()", GlobalVariables.goMySqlConnection);
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
                throw ex;
            }
        }
    }
}
