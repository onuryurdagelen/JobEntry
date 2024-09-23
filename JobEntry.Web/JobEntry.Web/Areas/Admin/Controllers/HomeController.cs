using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class HomeController : BaseController
    {
		public IActionResult Index()
		{
			return View();
		}
	}
}
