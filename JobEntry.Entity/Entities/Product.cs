using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Int16 Quantity { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public ICollection<Wish> Wishes { get; set; } = new HashSet<Wish>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();


    }
}
