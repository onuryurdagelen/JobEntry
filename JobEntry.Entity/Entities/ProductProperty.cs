using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class ProductProperty:IBaseEntity
    {
        public Guid Id { get; set; }
        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();

    }
}
