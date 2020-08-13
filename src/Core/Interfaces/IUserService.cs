using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> Users { get; }

        void Add(User user);
        void ModifyRole(string userId, string roleName);
    }
}
