using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
namespace EchoSystems.DIIA.Configuration.Data_Access_Objects
{
    class LogsDAO
    {
        public DataTable getLogs(DateTime pFrom, DateTime pTo, string pUser)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetLogs('" + string.Format("{0:yyyy-MM-dd}", pFrom) + "','" + string.Format("{0:yyyy-MM-dd}", pTo) + "','" + pUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
