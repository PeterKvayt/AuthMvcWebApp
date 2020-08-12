using System;

namespace Core.Models
{
    [Serializable]
    public sealed class User
    {
        #region Constructors

        public User(string email, string password, Role role)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Role = role;
        }

        #endregion

        #region Properties

        public readonly Guid Id;

        public string Email { get; set; }
        //{
        //    get { return Email; }
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            Email = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //}

        public string Password { get; set; }
        //{
        //    get { return Password; }
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            Password = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //}

        public Role Role { get; set; }
        //{
        //    get { return Role; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            Role = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //}

        #endregion
    }
}
