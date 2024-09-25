using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class WorkType:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
