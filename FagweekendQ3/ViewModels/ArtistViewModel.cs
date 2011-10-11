using System.ComponentModel.DataAnnotations;

namespace FagweekendQ3.ViewModels
{
    public class ArtistViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5)]
        public string Name { get; set; }
    }
}