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
    public class HomeCardController : Controller
    {
        
        private readonly AppDbContext _context;

        public HomeCardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<HomeCard> cards = await _context.HomeCards.ToListAsync();

            return View(cards);
        }

        public async Task<IActionResult> Detail(int id)
        {
            HomeCard homeCard = await _context.HomeCards.FirstOrDefaultAsync(p => p.Id == id);
            if (homeCard == null) return NotFound();

            return View(homeCard);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(HomeCard card)
        {
            if (!ModelState.IsValid) return View();

            await _context.HomeCards.AddAsync(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            HomeCard card = await _context.HomeCards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id,HomeCard card)
        {
            if (!ModelState.IsValid) return View();
            HomeCard existedCard = await _context.HomeCards.FirstOrDefaultAsync(x => x.Id == id);
            if (existedCard == null) return NotFound();

            if(id != card.Id)
            {
                return BadRequest();
            }

            existedCard.Icon = card.Icon;
            existedCard.Title = card.Title;
            existedCard.SubTitle = card.SubTitle;

            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            HomeCard card = await _context.HomeCards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCard(int id)
        {
            HomeCard existedCard = await _context.HomeCards.FirstOrDefaultAsync(c => c.Id == id);
            if (existedCard == null) return View();

            _context.HomeCards.Remove(existedCard);
            await _context.SaveChangesAsync();

            return View(existedCard);
        }
    }
}
