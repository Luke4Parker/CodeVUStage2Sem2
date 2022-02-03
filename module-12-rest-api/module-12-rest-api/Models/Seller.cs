using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class Seller
    {
        [Key]
        [Required]
        [Display(Name="sellerID")]
        public string SellerId { get; set; }

        [Required]
        [Display(Name="sellerName")]
        public string SellerName { get; set; }

        [Required]
        [Display(Name="sellerInventory")]
        public virtual List<InventoryItem> Inventory { get; set; }

    }
}
