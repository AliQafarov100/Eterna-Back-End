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
    public class CardController : Controller
    {
        private readonly AppDbContext _context;
        public CardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<Card> cards = await _context.Cards.ToListAsync();
            return View(cards);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Card card)
        {
            if (!ModelState.IsValid) return NotFound();

            await _context.Cards.AddAsync(card);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(int id,Card card)
        {
            if (!ModelState.IsValid) return View();
            Card existedCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (existedCard == null) return NotFound();

            if(card.Id != id)
            {
                return BadRequest();
            }

            existedCard.Icon = card.Icon;
            existedCard.Title = card.Title;
            existedCard.SubTitle = card.SubTitle;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
