using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Extensions
{
    public static class IdentityResultExtension
    {
        public static void AddToModelState(this IdentityResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(string.Empty,error.Description);
            }
        }
    }
}
