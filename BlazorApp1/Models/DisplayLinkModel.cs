using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class DisplayLinkModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "Url is too long.")]
        public string Url { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}