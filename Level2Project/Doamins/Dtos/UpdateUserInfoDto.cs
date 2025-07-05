using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Dtos
{
    public class UpdateUserInfoDto
    {
        public GetUserInfoResponseDto GetUserInfoResponseDto { get; set; }
        public AddUserResponseDto AddUserResponseDto { get; set; }
    }
}
