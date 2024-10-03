using JobEntry.Business.Services.Abstracts;
using JobEntry.Business.Services.Concretes;
using JobEntry.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModalController : Controller
    {
        private readonly ViewRenderService _viewRenderService;

        public ModalController(ViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadModalContent(string title)
        {
            // Render the partial view as a string
            var htmlContent = await _viewRenderService.RenderToStringAsync("/Shared/_AddQualificationForm.cshtml", null);


            var modalViewModel = new ModalViewModel
            {
                Title = title,
                Content = htmlContent
            };

            return PartialView("_ModalPartial", modalViewModel);
        }
    }
}
