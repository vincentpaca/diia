using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Data_Access_Objects;
namespace EchoSystems.DIIA.Configuration.Models
{
    class Logs
    {
        private LogsDAO loLogsDAO;
        public Logs()
        {
            loLogsDAO = new LogsDAO();
        }
        public DataTable getLogs(DateTime pFrom, DateTime pTo, string pUser)
        {
            return loLogsDAO.getLogs(pFrom, pTo, pUser);
        }
    }
}
