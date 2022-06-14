using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.DAL;
using Eterna_Back_End.Models;
using Eterna_Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            List<MiniCard> miniCards = await _context.MiniCards.ToListAsync();
            List<AboutDescript> aboutDescripts = await _context.AboutDescripts.ToListAsync();
            List<AboutImage> aboutImages = await _context.AboutImages.ToListAsync();
            List<AboutMain> aboutMains = await _context.AboutMains.ToListAsync();
            List<AboutToDoList> aboutToDoLists = await _context.AboutToDoLists.ToListAsync();
            List<HomeCard> homeCards = await _context.HomeCards.ToListAsync();
            List<Carousel> carousels = await _context.Carousels.ToListAsync();
            HomeVM model = new HomeVM
            {
                Sliders = sliders,
                MiniCards = miniCards,
                AboutDescripts = aboutDescripts,
                AboutImages = aboutImages,
                AboutMains = aboutMains,
                AboutToDoLists = aboutToDoLists,
                HomeCards = homeCards,
                Carousels = carousels
            };
            return View(model);
        }
    }
}
