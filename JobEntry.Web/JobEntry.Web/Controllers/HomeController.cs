using JobEntry.Business.Services.Abstracts;
using JobEntry.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobEntry.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICompanyService _companyService;
		public HomeController(ILogger<HomeController> logger,ICompanyService companyService)
		{
			_logger = logger;
			_companyService = companyService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _companyService.GetAllCompaniesAsync();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
