using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class RoleManager : IRoleManager
    {
        private const string DEFAULT_USER_ROLE = "user";

        private const string ADMIN_ROLE = "admin";

        /// <summary>
        /// Returns default user role.
        /// </summary>
        /// <returns></returns>
        public Role GetDefaultUserRole()
        {
            return new Role(DEFAULT_USER_ROLE);
        }

        /// <summary>
        /// Returns admin role.
        /// </summary>
        /// <returns></returns>
        public Role GetAdminRole()
        {
            return new Role(ADMIN_ROLE);
        }
    }
}
