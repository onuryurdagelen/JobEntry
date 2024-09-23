using FluentValidation;
using JobEntry.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.FluentValidations
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.SalaryStart)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.SalaryEnd)
               .NotEmpty()
               .NotNull()
               .GreaterThan(0);

            RuleFor(x => x.DateLine)
                .NotEmpty()
                .NotNull();

        }
    }
}
