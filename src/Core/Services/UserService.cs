using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public sealed class UserService : IUserService
    {
        private IRepository _repository;

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
    }
}
