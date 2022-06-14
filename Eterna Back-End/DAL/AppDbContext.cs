using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eterna_Back_End.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<AnotherDescription> AnotherDescriptions { get; set; }
        public DbSet<Information> informations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AnotherSetting> AnotherSettings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<MiniCard> MiniCards { get; set; }
        public DbSet<AboutDescript> AboutDescripts { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<AboutMain> AboutMains { get; set; }
        public DbSet<AboutToDoList> AboutToDoLists { get; set; }
        public DbSet<HomeCard> HomeCards { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
    }
}
