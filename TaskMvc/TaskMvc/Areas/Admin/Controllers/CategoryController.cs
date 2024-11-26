using Microsoft.AspNetCore.Mvc;

namespace TaskMvc.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
