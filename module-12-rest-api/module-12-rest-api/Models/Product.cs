using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "productNumber")]
        public string ProductNumber { get; set; }

        [Required]
        [Display(Name = "productName")]
        public string ProductName { get; set; }

        [Required]
        [Range(10, 90)]
        [Display(Name = "price")]
        public double? Price { get; set; }

        [Required]
        [Display(Name = "department")]
        public string Department { get; set; }
        [Required]
        [Display(Name = "relatedProducts")]
        public virtual List<RelatedProduct> RelatedProducts { get; set; }

        [Required]
        [Display(Name = "reviews")]
        public virtual List<Review> Reviews { get; set; }

        [Required]
        [Display(Name = "dateUpdated")]
        public DateTime DateUpdated { get; set; }


    }
}
