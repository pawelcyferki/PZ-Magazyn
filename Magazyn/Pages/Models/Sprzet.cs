using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Magazyn.Pages.Models;

using Microsoft.EntityFrameworkCore;

namespace Magazyn.Pages.Models
{
    public class Sprzet
    {

        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string SN { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string producent { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Model { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [EmailAddress]
        public string osobaPrzypisana { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string lokalizacja { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string status { get; set; } = string.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string typ { get; set; } = string.Empty;

       
    }
}
