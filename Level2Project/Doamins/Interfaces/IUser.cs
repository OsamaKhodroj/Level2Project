using Domains.Dtos;
using Domains.Entities;
using Domains.Enums;

namespace Domains.Interfaces
{
    public interface IUser
    {
        Task<AddUserResponseDto> AddAsync(AddUserRequestDto user);
        Task<AddUserResponseDto> UpdateAsync(User user);
        Task<AddUserResponseDto> DeleteAsync(Guid id);
        Task<GetUserInfoResponseDto> GetByIdAsync(Guid id);
        Task<List<GetUsersListDto>> GetAllAsync(); 

    }
}
