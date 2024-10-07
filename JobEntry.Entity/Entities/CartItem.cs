using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class CartItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
