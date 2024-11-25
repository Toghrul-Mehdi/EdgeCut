using Microsoft.AspNetCore.Mvc;

namespace TaskMvc.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
