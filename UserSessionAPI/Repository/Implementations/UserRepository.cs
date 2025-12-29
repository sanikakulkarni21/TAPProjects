using UserSessionAPI.Helpers;
using UserSessionAPI.Models;
using UserSessionAPI.Repository.Interfaces;

namespace UserSessionAPI.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath;

        public UserRepository()
        {
           _filePath = Path.Combine(
    AppContext.BaseDirectory,
    "Data",
    "Users.json"
);
 
        }

        public User? GetByUsername(string username)
        {
            var users = JsonFileHelper.ReadFromFile<User>(_filePath);
            return users.FirstOrDefault(u => u.Username == username);
        }

        public User Add(User user)
        {
            var users = JsonFileHelper.ReadFromFile<User>(_filePath);

            user.Id = users.Count + 1;
            users.Add(user);

            JsonFileHelper.WriteToFile(_filePath, users);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return JsonFileHelper.ReadFromFile<User>(_filePath);
        }

        public User? GetById(int id)
        {
            var users = JsonFileHelper.ReadFromFile<User>(_filePath);
            return users.FirstOrDefault(u => u.Id == id);
        }


    }
}
