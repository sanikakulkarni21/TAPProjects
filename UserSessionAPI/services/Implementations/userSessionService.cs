using UserSessionAPI.Models;
using UserSessionAPI.Repository.Interfaces;
using UserSessionAPI.services.Interfaces;

namespace UserSessionAPI.services.Implementations
{
    public class userSessionService : IuserSessionService
    {
        private readonly IUserRepository _userRepository;

        public userSessionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Register(Register request)
        {
            var existingUser = _userRepository.GetByUsername(request.Username);
            if (existingUser != null)
                return null;

            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };

            return _userRepository.Add(user);
        }

        public User? Login(login request)
        {
            var user = _userRepository.GetByUsername(request.Username);

            if (user == null || user.Password != request.Password)
                return null;

            return user;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }





    }
}
