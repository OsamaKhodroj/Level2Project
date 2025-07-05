using Domains.Dtos;
using Domains.Entities;
using Domains.Enums;
using Domains.Interfaces;
using Infrastructure;

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

        public async Task<AddUserResponseDto> AddAsync(AddUserRequestDto request)
        {
            var response = new AddUserResponseDto();

            try
            {
                await Task.CompletedTask;
                var isValidate = IsValidUser(request);

                if (isValidate)
                {
                    var user = new User()
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        Address = request.Address,
                        Password = request.Password,
                        PhoneNumber = request.PhoneNumber
                    };
                    user.Id = Guid.NewGuid();
                    user.StatusType = Domains.Enums.StatusTypeEnum.Active;
                    user.IsDeleted = false;
                    user.UserType = Domains.Enums.UserTypeEnum.User;
                    user.Password = Encryption.Hash(user.Password);

                    _users.Add(user);
                    response.Status = OpStatus.Success;
                    response.Message = "User Added Sucessfully";
                }
                else
                {
                    response.Status = OpStatus.Warning;
                    response.Message = "Email address or phone number is already exists";
                }
            }
            catch (Exception)
            {
                response.Status = OpStatus.Error;
                response.Message = "Sorry we have something error please try again later";
            }
            return response;
        }

        public async Task<AddUserResponseDto> DeleteAsync(Guid id)
        {
            var response = new AddUserResponseDto();
            await Task.CompletedTask;

            if (id == Guid.Empty)
                throw new ArgumentException("id is required");


            var userInfo = _users.Where(x => x.Id == id).FirstOrDefault();
            if (userInfo != null)
            {
                userInfo.IsDeleted = true;
            }
            return response;
        }

        public async Task<List<GetUsersListDto>> GetAllAsync()
        {
            await Task.CompletedTask;
            var result = _users.Where(x => !x.IsDeleted)
                .Select(q => new GetUsersListDto()
                {
                    Email = q.Email,
                    FullName = q.FullName,
                    Id = q.Id,
                    PhoneNumber = q.PhoneNumber,
                    StatusType = q.StatusType,
                    UserType = q.UserType,
                })
                .ToList();

            return result;
        }

        public async Task<GetUserInfoResponseDto> GetByIdAsync(Guid id)
        {
            await Task.CompletedTask;

            if (id == Guid.Empty)
                throw new ArgumentException("id is required");

            var userInfo = _users.Where(x => x.Id == id && !x.IsDeleted)
                .Select(q => new GetUserInfoResponseDto()
                {
                    Address = q.Address,
                    Email = q.Email,
                    FullName = q.FullName,
                    Id = q.Id,
                    PhoneNumber = q.PhoneNumber,
                    StatusType = q.StatusType,
                    UserType = q.UserType
                })
                .FirstOrDefault();

            return userInfo;
        }

        public async Task<AddUserResponseDto> UpdateAsync(User user)
        {
            await Task.CompletedTask;

            var response = new AddUserResponseDto();
            return response;
        }


        private bool IsValidUser(AddUserRequestDto request)
        {
            if (request == null)
                return false;

            var isUserExists = _users.Any(q => q.Email == request.Email || q.PhoneNumber == request.PhoneNumber);
            if (isUserExists)
                return false;

            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return false;
            }
            // Additional validation logic can be added here
            return true;
        }
    }
}
