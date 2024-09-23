using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
	public class Company:BaseEntity
	{
        public Company()
        {
            
        }
        public Company(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Company(string name,string description,Image image)
        {
            Name = name;
            Description = description;
            Image = image; 
        }
        public Company(string name, string description, Employer employer)
        {
            Name = name;
            Description = description;
            Employer = employer;
        }
        public Company(string name, string description,Image image, Employer employer)
        {
            Name = name;
            Description = description;
            Image= image;
            Employer = employer;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }

        public Employer? Employer { get; set; }
    }
}
