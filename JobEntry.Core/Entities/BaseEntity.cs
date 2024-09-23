﻿using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Core.Entities
{
	public abstract class BaseEntity: IBaseEntity
	{
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
