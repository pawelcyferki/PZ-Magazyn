using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Magazyn.Pages.Models;


namespace Magazyn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Magazyn.Pages.Models.Sprzet>? Sprzet { get; set; }
        public DbSet<Magazyn.Pages.Models.Lokacja>? Lokacja { get; set; }
        
    }
}