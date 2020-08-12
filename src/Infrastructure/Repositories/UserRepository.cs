using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public sealed class UserRepository : IRepository
    {
        private IList<User> _users = new List<User> { };
        //{
        //    new User("mail","pass", new Role("user")),
        //    new User("mail1","pass", new Role("user")),
        //    new User("mail2","pass", new Role("admin")),
        //    new User("mail3","pass", new Role("user")),
        //};

        public IList<User> Users 
        {
            get
            {
                _users = GetUsers();
                SetMockUsers();
                return _users;
            }
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

        private IList<User> GetUsers()
        {
            using (var stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FILE_NAME, FileMode.OpenOrCreate))
            {
                try
                {
                    return JsonSerializer.DeserializeAsync<IList<User>>(stream).Result;
                }
                catch(JsonException exception)
                {
                    return new List<User>() { };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private void SetMockUsers()
        {
            var mockUser = _users.FirstOrDefault(user => user.Email == "user@m");

            if (mockUser == null)
            {
                _users.Add(new User("user@m", "1", new Role("user")));
            }

            var mockAdmin = _users.FirstOrDefault(user => user.Email == "admin@m");

            if (mockAdmin == null)
            {
                _users.Add(new User("admin@m", "1", new Role("admin")));
            }
        }

        private const string FILE_NAME = "users.json";

        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            using (var stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FILE_NAME, FileMode.OpenOrCreate))
            {
                    JsonSerializer.SerializeAsync<IList<User>>(stream, _users, options);
            }
        }
    }
}
