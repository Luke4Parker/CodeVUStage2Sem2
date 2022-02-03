using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class InventoryItem

    {
        [Key]
        [Display(Name="inventoryId")]
        public int InventoryId { get; set; }

        [Required]
        [Display(Name="sellerName")]
        public string SellerName { get; set; }

        [Required]
        [Display(Name= "productNumber")]
        public string ProductNumber { get; set; }
        [Required]
        [Display(Name = "numberHeld")]
        public int NumberHeld { get; set; }
        [Required]
        [Display(Name = "numberSold")]
        public int NumberSold { get; set; }

    }
}
