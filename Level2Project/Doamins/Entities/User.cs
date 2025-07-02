using Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class User : EntityBase<Guid>
    {
        public override Guid Id { get => base.Id; set => base.Id = Guid.NewGuid(); }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public UserTypeEnum  UserType { get; set; }
        public StatusTypeEnum StatusType { get; set; }

    }
}
