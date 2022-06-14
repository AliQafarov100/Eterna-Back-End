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
    public class CarouselController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CarouselController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Carousel> carousels = await _context.Carousels.ToListAsync();

            return View(carousels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Carousel carousel)
        {
            if (!ModelState.IsValid) return NotFound();
            if(carousel.Photo != null)
            {
                if(carousel.Photo.Length > 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Size of image mustn't more than 1Mb");
                }

                string fileName = carousel.Photo.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "Image","Home", "ForCarousel");
                string fullPath = Path.Combine(path, fileName);

                using(FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await carousel.Photo.CopyToAsync(stream);
                }

                carousel.Image = fileName;
                await _context.Carousels.AddAsync(carousel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose image file");
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            Carousel carousel = await _context.Carousels.FirstOrDefaultAsync(c => c.Id == id);

            if (carousel == null) return NotFound();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id,Carousel carousel)
        {
            if (!ModelState.IsValid) return View();
            Carousel existedCarousel = await _context.Carousels.FirstOrDefaultAsync(c => c.Id == id);

            if(carousel.Photo != null)
            {
                if(carousel.Photo.Length > 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Size of image mustn't more than 1Mb");
                    return View();
                }
                else
                {
                    string fileName = carousel.Photo.FileName;
                    string path = Path.Combine(_env.WebRootPath, "assets", "Image", "Home", "ForCarousel");
                    string fullPath = Path.Combine(path, fileName);

                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await carousel.Photo.CopyToAsync(stream);
                    }

                    string anyPath = _env.WebRootPath + @"assets\Image\Home\ForCarousel\" + carousel.Image;

                    if (System.IO.File.Exists(anyPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    existedCarousel.Image = fileName;
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose image file");
                return View();
            }

            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
