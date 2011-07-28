using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Data_Access_Objects;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.Configuration.Models
{
    public class Employee
    {
        EmployeeDAO loEmployeeDAO;

        public Employee()
        {
            loEmployeeDAO = new EmployeeDAO();
        }

        public Employee(string pEmployeeID) : this()
        {
            object _oEmployee = this;
            GlobalFunctions.BindAttribute(ref _oEmployee, getDetailsByID(pEmployeeID));
        }

        public string EmployeeId
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string EmployeeType
        {
            get;
            set;
        }

        public string Initials
        {
            get;
            set;
        }

        public DataTable getByType(string pType)
        {
            return loEmployeeDAO.getByType(pType);
        }

        public DataTable getDetailsByID(string pEmployeeId)
        {
            return loEmployeeDAO.getDetailsByID(pEmployeeId);
        }

        public bool delete(string pEmployeeId)
        {
            return loEmployeeDAO.delete(pEmployeeId);
        }

        public DataTable get()
        {
            return loEmployeeDAO.get();
        }

        public string insert()
        {
            return loEmployeeDAO.insert(this);
        }

        public void update()
        {
            loEmployeeDAO.update(this);
        }
    }
}
