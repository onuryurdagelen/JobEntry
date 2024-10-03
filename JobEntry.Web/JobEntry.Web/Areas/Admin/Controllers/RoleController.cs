using JobEntry.Business.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _roleService.GetAllRolesAsync();
            return View(response.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {

            return View();
        }
    }
}
