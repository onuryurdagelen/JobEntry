using JobEntry.Business.Services.Concretes;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

       
        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetAllUsersAsync();
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
