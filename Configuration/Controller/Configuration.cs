using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Models;
using EchoSystems.Administration.Models;
namespace EchoSystems.DIIA.Configuration.Controller
{
    public class Configuration
    {
        Section loSection;
        Newspaper loNewspaper;
        Employee loEmployee;
        EmployeeType loEmployeeType;

        public Configuration()
        {
            loSection = new Section();
            loNewspaper = new Newspaper();
            loEmployee = new Employee();
            loEmployeeType = new EmployeeType();
        }

        public DataTable getSections(string pNewspaperId)
        {
            return loSection.get(pNewspaperId);
        }

        public string getSectionName(string pSectionName)
        {
            return loSection.getSectionName(pSectionName);
        }

        public string getUserDefaultSection()
        {
            return loSection.getUserDefaultSection();
        }

        public DataTable getNewspapers()
        {
            return loNewspaper.get();
        }

        public DataTable getEmployeesByType(string pType)
        {
            return loEmployee.getByType(pType);
        }

        public DataTable getEmployeeTypes()
        {
            return loEmployeeType.get();
        }

        public Employee getEmployeeDetailsByID(string pEmployeeId)
        {
            return loEmployee = new Employee(pEmployeeId);
        }

        public DataTable getEmployees()
        {
            return loEmployee.get();
        }

        public string insertEmployee(string pFirstName, string pLastName, string pMiddleName, string pInitials, string pType)
        {
            loEmployee.FirstName = pFirstName;
            loEmployee.MiddleName = pMiddleName;
            loEmployee.LastName = pLastName;
            loEmployee.Initials = pInitials;
            loEmployee.EmployeeType = pType;
            return loEmployee.insert();
        }

        public void updateEmployee(string pEmployeeId, string pFirstName, string pLastName, string pMiddleName, string pInitials, string pType)
        {
            loEmployee.EmployeeId = pEmployeeId;
            loEmployee.FirstName = pFirstName;
            loEmployee.MiddleName = pMiddleName;
            loEmployee.LastName = pLastName;
            loEmployee.Initials = pInitials;
            loEmployee.EmployeeType = pType;
            loEmployee.insert();
        }

        public void deleteEmployee(string pEmployeeId)
        {
            loEmployee.delete(pEmployeeId);
        }

        public DataTable getLogs(DateTime pFrom, DateTime pTo, string pUser)
        {
            Logs _logs = new Logs();
            return _logs.getLogs(pFrom, pTo, pUser);
        }

        public DataTable getUsers()
        {
            User _user = new User();
            return _user.get();
        }
    }
}
