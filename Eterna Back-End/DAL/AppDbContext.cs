using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<AnotherDescription> AnotherDescriptions { get; set; }
        public DbSet<Information> informations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AnotherSetting> AnotherSettings { get; set; }
    }
}
