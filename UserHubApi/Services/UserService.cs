using Microsoft.AspNetCore.Mvc;
using UserHubApi.Models;

namespace UserHubApi.Services
{
    public interface IUserService
    {
        User Add(User user);
        User GetById(int? id);
        IEnumerable<User> GetAll();
        void Update(User user);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { id = 1, firstName = "Sarah", lastName = "Doe", birthDate = "1991-01-05" },
            new User { id = 2, firstName = "Adrian", lastName = "Smith", birthDate = "1995-07-15" },
            new User { id = 3, firstName = "Nicole", lastName = "Johnson", birthDate = "1992-10-21" }
        };

        private int _nextId = 4;

        public User Add([FromBody] User user)
        {
            user.id = _nextId++;
            _users.Add(user);
            return user;
        }

        public User GetById(int? id)
        {
            return _users.FirstOrDefault(u => u.id == id);
        }

        public IEnumerable<User> GetAll() => _users;

        public void Update(User user)
        {
            var existingUser = GetById(user.id);
            if (existingUser != null)
            {
                existingUser.firstName = user.firstName;
                existingUser.lastName = user.lastName;
                existingUser.birthDate = user.birthDate;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
