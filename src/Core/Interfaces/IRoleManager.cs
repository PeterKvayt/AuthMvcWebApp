using Core.Models;

namespace Core.Interfaces
{
    public interface IRoleManager
    {
        Role GetDefaultUserRole();

        Role GetAdminRole();
    }
}
