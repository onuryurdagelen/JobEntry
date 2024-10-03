using JobEntry.Entity.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }

        public JobEntry.Entity.Entities.Image? Image { get; set; }
    }
}
