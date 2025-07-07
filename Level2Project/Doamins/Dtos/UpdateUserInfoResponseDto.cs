using Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Dtos
{
    public class GetUserInfoResponseDto
    {
        public Guid Id { get; set; }
         
        public string FullName { get; set; }
         
        public string Email { get; set; } 
         
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public UserTypeEnum UserType { get; set; }
        public StatusTypeEnum StatusType { get; set; }
    }
}
