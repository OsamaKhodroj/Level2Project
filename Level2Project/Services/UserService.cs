using Domains.Entities;
using Domains.Interfaces;

namespace Services
{
    public class UserService : IUser
    {
        private static List<User> _users;

        public UserService()
        {
            if (_users == null)
            {
                _users = new List<User>();
            }
        }

        public async Task AddAsync(User user)
        {
            try
            {
                await Task.CompletedTask;

                var isValidate = IsValidUser(user);

                if (isValidate)
                {
                    user.Id = Guid.NewGuid();
                    _users.Add(user);
                }
            }
            catch (Exception)
            {
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await Task.CompletedTask;

            if (id == Guid.Empty)
                throw new ArgumentException("id is required");


            var userInfo = _users.Where(x => x.Id == id).FirstOrDefault();
            if (userInfo != null)
            {
                userInfo.IsDeleted = true;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            await Task.CompletedTask;
            var result = _users.Where(x => !x.IsDeleted)
                .ToList();

            return result;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            await Task.CompletedTask;

            if (id == Guid.Empty)
                throw new ArgumentException("id is required");

            var userInfo = _users.Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefault();

            return userInfo;
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }


        private bool IsValidUser(User user)
        {
            if (user == null)
                return false;


            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }
            // Additional validation logic can be added here
            return true;
        }
    }
}
