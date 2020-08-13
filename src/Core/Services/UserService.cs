using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> Users => _repository.Users;

        public void Add(User user)
        {
            _repository.Users.Add(user);
            _repository.Save();
        }

        public void ModifyRole(string userId, string roleName)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user != null)
            {
                user.Role.Name = roleName;
                _repository.Save();
            }
        }
    }
}
