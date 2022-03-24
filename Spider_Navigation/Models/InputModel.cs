using System.ComponentModel.DataAnnotations;

namespace Spider_Navigation.Models
{
    public class InputModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "X for Rectangle")]
        public int RectX { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Y for Rectangle")]
        public int RectY { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "X for Spidy")]
        public int SpidX { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Y for Spidy")]
        public int SpidY { get; set; }


        [Required]
        [Display(Name = "Direction for Spidy")]
        public string SpidDirection { get; set; }


        [Required]
        [Display(Name = "Instructions for Spidy")]
        public string Instrctions { get; set; }

    }
}