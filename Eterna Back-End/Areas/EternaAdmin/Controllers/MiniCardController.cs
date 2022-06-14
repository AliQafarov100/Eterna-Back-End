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
    public class MiniCardController : Controller
    {
        private readonly AppDbContext _context;

        public MiniCardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<MiniCard> card = await _context.MiniCards.ToListAsync();

            return View(card);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(MiniCard card)
        {
            if (!ModelState.IsValid) return NotFound();

            _context.MiniCards.Add(card);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            MiniCard card = await _context.MiniCards.FirstOrDefaultAsync(c => c.id == id);
            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id,MiniCard card)
        {
            if (!ModelState.IsValid) return NotFound();
            MiniCard existedCard = await _context.MiniCards.FirstOrDefaultAsync(c => c.id == id);

            if (existedCard == null) return View();

            if (card.id != id) return BadRequest();

            existedCard.Icon = card.Icon;
            existedCard.Title = card.Title;
            existedCard.Description = card.Description;

            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            MiniCard card = await _context.MiniCards.FirstOrDefaultAsync(c => c.id == id);

            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCard(int id)
        {
            MiniCard card = await _context.MiniCards.FirstOrDefaultAsync(c => c.id == id);

            if (card == null) return View();

            _context.Remove(card);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            MiniCard card = await _context.MiniCards.FirstOrDefaultAsync(s => s.id == id);

            return View(card);
        }
    }
}
