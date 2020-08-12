using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Infrastructure.Repositories
{
    public sealed class UserRepository : IRepository
    {
        private IList<User> _users = new List<User>
        {
            new User("mail","pass", new Role("user")),
            new User("mail1","pass", new Role("user")),
            new User("mail2","pass", new Role("admin")),
            new User("mail3","pass", new Role("user")),
        };

        public IList<User> Users 
        { 
            get => _users;
            set
            {
                if (value != null)
                {
                    _users = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public void Save()
        {
            var formatter = new DataContractJsonSerializer(typeof(User));

            using (var stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory, FileMode.OpenOrCreate, FileAccess.Write))
            {
                foreach (var user in _users)
                {
                    formatter.WriteObject(stream, user);
                }
            }
        }
    }
}
