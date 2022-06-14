using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.DAL;
using Eterna_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.Areas.EternaAdmin.Controllers
{
    [Area("EternaAdmin")]
    public class PhoneController : Controller
    {
        private readonly AppDbContext _context;
        public PhoneController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            AnotherSetting setting = await _context.AnotherSettings.FirstOrDefaultAsync(s => s.Id == id);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(AnotherSetting setting)
        {
            if (!ModelState.IsValid) return NotFound();

            _context.AnotherSettings.Add(setting);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        } 
    }
}
