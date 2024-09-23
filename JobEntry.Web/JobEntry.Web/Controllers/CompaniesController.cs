using JobEntry.Business.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICompanyService _companyService;
		public CompaniesController(ILogger<HomeController> logger, ICompanyService companyService)
		{
			_logger = logger;
			_companyService = companyService;
		}
		[HttpGet("get-data")]
		public IActionResult GetData() 
		{
			var result = _companyService.GetAllCompaniesAsync();
			return Ok(result);
		}
	}
}
