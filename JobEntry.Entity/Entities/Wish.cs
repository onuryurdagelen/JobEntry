using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Wish:IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
