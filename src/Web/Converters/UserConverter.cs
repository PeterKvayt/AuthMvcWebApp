using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;

namespace Web.Converters
{
    public static class UserConverter
    {
        public static UserViewModel Convert(User user)
        {
            return new UserViewModel
            {
                Email = user.Email,
                Password = user.Password,
                RoleName = user.Role.Name,
                Id = user.Id.ToString()
            };
        }

        public static IEnumerable<UserViewModel> Convert(IEnumerable<User> users)
        {
            var resultCollection = new List<UserViewModel> { };

            foreach (var user in users)
            {
                resultCollection.Add(Convert(user));
            }

            return resultCollection;
        }
    }
}
