using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.Administration.Data_Access_Objects;
using EchoSystems.Common.Global;
using System.Data;

namespace EchoSystems.Administration.Models
{
    public class User
    {
        UserDAO loUserDAO;

        public User()
        {
            loUserDAO = new UserDAO();
        }

        public User(string pUserId)
            : this()
        {
            object _oUser = this;
            GlobalFunctions.BindAttribute(ref _oUser, getDetailsByID(pUserId));
        }

        public string userID
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public string role
        {
            get;
            set;
        }

        public string defaultSection
        {
            get;
            set;
        }

        public void insert(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loUserDAO.insert(this, ref poMySqlTransaction);
        }

        public void update(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loUserDAO.update(this, ref poMySqlTransaction);
        }

        public void delete(string pUserId)
        {
            loUserDAO.delete(pUserId);
        }

        public DataTable get()
        {
            return loUserDAO.get();
        }

        public DataTable getDetailsByID(string pUserid)
        {
            return loUserDAO.getDetailsByID(pUserid);
        }

        public DataTable getSections()
        {
            return loUserDAO.getSections();
        }
    }
}
