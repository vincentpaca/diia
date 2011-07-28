using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using EchoSystems.Administration.Data_Access_Objects;
using MySql.Data.MySqlClient;
namespace EchoSystems.Administration.Models
{
    public class SystemRole
    {
        SystemRoleDAO loSystemRoleDAO;
        public SystemRole()
        {
            loSystemRoleDAO = new SystemRoleDAO();
        }
        public DataTable getRoleMenus(string pRoleName)
        {
            return loSystemRoleDAO.getRoleMenus(pRoleName);
        }

        public DataTable getUserRoleMenus()
        {
            return loSystemRoleDAO.getUserRoleMenus();
        }

        public DataTable getUserRoleForms()
        {
            return loSystemRoleDAO.getUserRoleForms();
        }

        public DataTable getUserRolePrivileges()
        {
            return loSystemRoleDAO.getUserRolePrivileges();
        }

        public DataTable getRoleForms(string pRoleName)
        {
            return loSystemRoleDAO.getRoleForms(pRoleName);
        }

        public DataTable getRolePrivileges(string pRoleName)
        {
            return loSystemRoleDAO.getRolePrivileges(pRoleName);
        }

        public DataTable getSystemPrivileges()
        {
            return loSystemRoleDAO.getSystemPrivileges();
        }

        public bool insertMenu(string pRoleName, string pMenu, bool pEnable, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.insertMenu(pRoleName, pMenu, pEnable, pTrans);
        }

        public bool updateMenu(string pRoleName, string pMenu, bool pEnable, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.updateMenu(pRoleName, pMenu, pEnable, pTrans);
        }

        public bool insertForm(string pRoleName, string pModule, string pForm, string pButton, bool pVisible, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.insertForm(pRoleName, pModule, pForm, pButton, pVisible, pTrans);
        }

        public bool updateForm(string pRoleName, string pModule, string pForm, string pButton, bool pVisible, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.updateForm(pRoleName, pModule, pForm, pButton, pVisible, pTrans);
        }

        public bool insertPrivilege(string pRoleName, string pPrivilege, bool pAllowed, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.insertPrivilege(pRoleName, pPrivilege, pAllowed, pTrans);
        }

        public bool updatePrivilege(string pRoleName, string pPrivilege, bool pAllowed, MySqlTransaction pTrans)
        {
            return loSystemRoleDAO.updatePrivilege(pRoleName, pPrivilege, pAllowed, pTrans);
        }
    }
}
