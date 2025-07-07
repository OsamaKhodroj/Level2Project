using Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domains.Entities
{
    public class User : EntityBase<Guid>
    {   
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public UserTypeEnum  UserType { get; set; } = UserTypeEnum.User;
        public StatusTypeEnum StatusType { get; set; } = StatusTypeEnum.Active;

    }
}
