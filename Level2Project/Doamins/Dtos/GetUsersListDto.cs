using Domains.Enums;

namespace Domains.Dtos
{
    public class GetUsersListDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; } 
         
        public string PhoneNumber { get; set; } 

        public UserTypeEnum UserType { get; set; } = UserTypeEnum.User;
        public StatusTypeEnum StatusType { get; set; } = StatusTypeEnum.Active;
    }
}
