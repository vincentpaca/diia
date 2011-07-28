using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.Administration.Data_Access_Objects;


namespace EchoSystems.Administration.Models
{
    public class UserRole
    {
        UserRoleDAO loUserRoleDAO;

        public UserRole()
        {
            loUserRoleDAO = new UserRoleDAO();
        }

        public string UserId
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public void insert(ref MySql.Data.MySqlClient.MySqlTransaction poMySqltransaction)
        {
            loUserRoleDAO.insert(this, ref poMySqltransaction);
        }

        public void update(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loUserRoleDAO.update(this, ref poMySqlTransaction);   
        }
    }
}
