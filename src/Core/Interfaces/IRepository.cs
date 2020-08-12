using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository
    {
        IList<User> Users { get; set; }

        void Save();
    }
}
