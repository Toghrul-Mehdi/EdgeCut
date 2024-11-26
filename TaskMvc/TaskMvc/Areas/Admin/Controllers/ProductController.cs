using Microsoft.AspNetCore.Mvc;

namespace TaskMvc.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
