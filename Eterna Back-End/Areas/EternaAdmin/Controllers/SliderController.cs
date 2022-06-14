using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.DAL;
using Eterna_Back_End.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.Areas.EternaAdmin.Controllers
{
    [Area("EternaAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return NotFound();

            if(slider.Photo != null)
            {
                if(slider.Photo.Length > 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Size of image mustn't more than 1MB");
                }

                string fileName = slider.Photo.FileName;
                string path = Path.Combine(_environment.WebRootPath, "assets", "Image", "Slider");
                string fullPath = Path.Combine(path, fileName);

                using(FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await slider.Photo.CopyToAsync(stream);
                }

                slider.Image = fileName;
                await _context.Sliders.AddAsync(slider);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            Slider slider =  await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
          
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id,Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if(slider.Photo != null)
            {
                if(slider.Photo.Length > 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Please choose file which size less than 1MB");
                    return View();
                }
                else
                {
                    string fileName = slider.Photo.FileName;
                    string path = Path.Combine(_environment.WebRootPath, "assets", "Image", "Slider");
                    string fullPath = Path.Combine(path, fileName);

                    using(FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await slider.Photo.CopyToAsync(stream);
                    }

                    string anyPath = _environment.WebRootPath + @"assets\Image\Slider\" + slider.Image;

                    if (System.IO.File.Exists(anyPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    existedSlider.Image = fileName;
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }

            existedSlider.Title = slider.Title;
            existedSlider.TitleDedicated = slider.TitleDedicated;
            existedSlider.SubTitle = slider.SubTitle;
            existedSlider.Order = slider.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(int id)
        {
            if (!ModelState.IsValid) return NotFound();
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            
            if(existedSlider == null)
            {
                return View();
            }
            _context.Remove(existedSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Sliders.OrderByDescending(p => p.Id == id).Take(3).FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }
    }
}
