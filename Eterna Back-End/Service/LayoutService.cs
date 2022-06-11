using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.DAL;
using Eterna_Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnotherSetting>> GetDatas()
        {
            List<AnotherSetting> anotherSetting = await _context.AnotherSettings.ToListAsync();

            return anotherSetting;
        }
      
    }
}
