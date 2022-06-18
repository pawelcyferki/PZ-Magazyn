using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Magazyn.Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Pages.Models
{
    [Keyless]
    public class AspNetUserSprzet
    {
        public string UserId { get; set; }
        public int SprzetId { get; set; }
    }
}