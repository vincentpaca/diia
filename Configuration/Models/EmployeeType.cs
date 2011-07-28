using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Data_Access_Objects;

namespace EchoSystems.DIIA.Configuration.Models
{
    public class EmployeeType
    {
        EmployeeTypeDAO loEmployeeTypeDAO;

        public EmployeeType()
        {
            loEmployeeTypeDAO = new EmployeeTypeDAO();
        }

        public DataTable get()
        {
            return loEmployeeTypeDAO.get();
        }
    }
}
