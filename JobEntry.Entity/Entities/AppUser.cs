using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using JobEntry.Core.Entities;

namespace JobEntry.Entity.Entities
{

    public class AppUser:IdentityUser<Guid>,IBaseEntity
    {

        public AppUser()
        {
            
        }
        public AppUser(string firstName,string lastName,string fullName)
        {
            FirstName = firstName; 
            LastName = lastName;
            FullName = fullName;
        }
        public AppUser(string firstName, string lastName, string fullName,Guid imageId)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            ImageId = imageId;
        }

        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }
        public Cart? Cart { get; set; }

    }

    public class Customer: AppUser
	{
    }
  
}
