using UserSessionAPI.Models;

namespace UserSessionAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User Add(User user);

        List<User> GetAllUsers();

        User? GetById(int id);

        
    }
}
