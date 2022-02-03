using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class Review
    {
        [Key]
        [Required]
        [Display(Name = "reviewNumber")]
        public string ReviewNumber { get; set; }

        [Required]
        [Display(Name = "reviewRating")]
        [Range(1,5)]
        public int ReviewRating { get; set; }

        [Required]
        [Display(Name = "reviewAuthor")]
        public string ReviewAuthor { get; set; }

        [Display(Name = "reviewText")]
        public string ReviewText { get; set; }

    }
}
