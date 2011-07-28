using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using EchoSystems.Administration.Data_Access_Objects;
using EchoSystems.Common.Global;

namespace EchoSystems.Administration.Models
{
    public class Role
    {
        #region "V A R I A B L E S"
        RoleDAO loRoleDAO;
        #endregion
        public Role()
        {
            loRoleDAO = new RoleDAO();

        }

        public Role(string pRoleName)
            : this()
        {
            Object _obj = this;
            GlobalFunctions.BindAttribute(ref _obj, getRole(pRoleName));
        }

        public string RoleName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string OutletId
        {
            get;
            set;
        }

        public DataTable getRoles()
        {
            return loRoleDAO.getRoles();
        }

        public bool insert()
        {
            return loRoleDAO.insert(this);
        }

        public bool update()
        {
            return loRoleDAO.update(this);
        }

        public DataTable getRole(string pRoleName)
        {
            return loRoleDAO.getRole(pRoleName);
        }

        public bool delete()
        {
            return loRoleDAO.delete(RoleName);
        }

        public bool isActive()
        {
            if (getRole(RoleName).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
