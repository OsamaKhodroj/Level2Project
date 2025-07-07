using Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Dtos
{
    public class AddUserResponseDto
    {
        public OpStatus Status { get; set; }
        public string Message { get; set; }
    }
}
