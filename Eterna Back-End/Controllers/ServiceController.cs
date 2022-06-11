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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Card> cards = await _context.Cards.ToListAsync();
            List<Progress> progresses = await _context.Progresses.ToListAsync();
            List<AnotherDescription> descriptions = await _context.AnotherDescriptions.ToListAsync();
            List<Information> informations = await _context.informations.ToListAsync();
            List<Skill> skills = await _context.Skills.ToListAsync();

            ServiceVM model = new ServiceVM
            {
                Cards = cards,
                Progresses = progresses,
                AnotherDescriptions = descriptions,
                informations = informations,
                Skills = skills
            };

            return View(model);
        }
    }
}
