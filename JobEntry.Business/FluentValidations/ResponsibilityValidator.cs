using FluentValidation;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.FluentValidations
{
    public class ResponsibilityValidator:AbstractValidator<Responsibility>
    {
        public ResponsibilityValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
        }
    }
}
