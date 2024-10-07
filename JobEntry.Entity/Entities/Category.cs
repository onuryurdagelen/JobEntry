using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();


    }
}
