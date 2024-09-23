using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JobEntry.Business.Extensions
{
    public static class FluentValidatonExtension
    {
        public static void AddToModelState(this FluentValidation.Results.ValidationResult result,ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
