using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Information:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    }
}
