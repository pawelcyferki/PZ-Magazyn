using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazyn.Pages.Models;

namespace Magazyn.Data
{
    public class MagazynContext : DbContext
    {
        public MagazynContext (DbContextOptions<MagazynContext> options)
            : base(options)
        {
        }

        public DbSet<Magazyn.Pages.Models.Sprzet>? Sprzet { get; set; }

        public DbSet<Magazyn.Pages.Models.Lokacja>? Lokacja { get; set; }
    }
}
