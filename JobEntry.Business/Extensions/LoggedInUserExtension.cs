using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Extensions
{
    public static class LoggedInUserExtension
    {
        public static Guid GetLoggedInUserId(this ClaimsPrincipal principal) 
        {
            return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetLoggedInEmailAddress(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
        public static string GetLoggedInFullName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("FullName");
        }
        public static bool IsLoggedInUserInRole(this ClaimsPrincipal principal,string role)
        {
            return principal.IsInRole(role);
        }
    }
}
