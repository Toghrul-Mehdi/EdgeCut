using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMvc.DataAccess;
using TaskMvc.Models;
using TaskMvc.ViewModel.SliderVM;

namespace TaskMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(MvcDbContext _context, IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Sliders()
        {
            return View(await _context.Sliders.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSlider vm)
        {
            if (!vm.File.ContentType.StartsWith("image"))
                ModelState.AddModelError("File", "File type must be image");
            if (vm.File.Length > 600 * 1024)
                ModelState.AddModelError("File", "File length must be less than 600kb");
            if (!ModelState.IsValid) return View();

            string newFileName = Path.GetRandomFileName() + Path.GetExtension(vm.File.FileName);

            using (Stream stream = System.IO.File.Create(Path.Combine(_env.WebRootPath, "photos", "sliders", newFileName)))
            {
                await vm.File.CopyToAsync(stream);
            }

            Slider slider = new Slider
            {
                ImageUrl = newFileName,
                Link = vm.Link,
                Description = vm.Subtitle,
                Title = vm.Title,
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Sliders));
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, CreateSlider vm)
        {
            if (!ModelState.IsValid) return View();


            if (!vm.File.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("File", "File type must be image");
                return View();
            }

            if (vm.File.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("File", "File size must be less than 5MB");
                return View();
            }

            var data = await _context.Sliders.FindAsync(id);

            if (data is null) return View();

            string newFileName = Path.GetRandomFileName() + Path.GetExtension(vm.File.FileName);

            using (Stream stream = System.IO.File.Create(Path.Combine(_env.WebRootPath, "photos", "sliders", newFileName)))
            {
                await vm.File.CopyToAsync(stream);
            }

            data.ImageUrl = newFileName;
            data.Link = vm.Link;
            data.Description = vm.Subtitle;
            data.Title = vm.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Sliders));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);

            if (data is null) return View();


            _context.Sliders.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Sliders));
        }

        public async Task<IActionResult> Hide(int id, CreateSlider vm)
        {
            var data = await _context.Sliders.FindAsync(id);

            if (data is null) return View();

            data.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Sliders));
        }
        public async Task<IActionResult> Show(int id, CreateSlider vm)
        {
            var data = await _context.Sliders.FindAsync(id);

            if (data is null) return View();

            data.IsDeleted = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Sliders));
        }

    }
}
