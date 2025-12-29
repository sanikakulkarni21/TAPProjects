using UserSessionAPI.Models;

namespace UserSessionAPI.services.Interfaces
{
    public interface IuserSessionService
    {
        User? Register(Register request);
        User? Login(login request);
         List<User> GetAllUsers();
         User? GetById(int id);
    }
}
