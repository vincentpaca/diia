using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.Administration.Data_Access_Objects;

namespace EchoSystems.Administration.Models
{
    public class LoginDetails
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        LoginDetailsDAO loLoginDetailsDAO;

        public string loginUser()
        {
            loLoginDetailsDAO = new LoginDetailsDAO();
            return loLoginDetailsDAO.loginUser(this);
        }
    }
}
