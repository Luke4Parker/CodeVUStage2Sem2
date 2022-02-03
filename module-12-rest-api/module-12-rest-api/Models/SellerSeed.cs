using module_12_rest_api.Daos;
using module_12_rest_api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class SellerSeed
    {
        public static void InitSellerData(ProductContext context)
        {
            var rnd = new Random();
            var sellers = new[] { "SellsALot", "FormerlyKMart", "WallyWurld", "JupiterJeans", "Howard-Franklin" };
            var id = 1;
            context.Sellers.AddRange(3.Times(s =>
            {

                var seller = sellers[rnd.Next(0, 5)];
                var sellerId = id;
                id++;

                //Builds the Inventory list for the seller
                List<InventoryItem> inventory = new List<InventoryItem>();
                foreach (Product product in context.Products)
                {
                    inventory.Add(new InventoryItem
                    {
                        SellerName = seller,
                        ProductNumber = product.ProductNumber,
                        NumberHeld = 100,
                        NumberSold = 0
                    });
                }

                return new Seller
                {
                    SellerName = seller,
                    SellerId = sellerId.ToString(),
                    Inventory = inventory
                };
            }));

            context.SaveChanges();
        }
        
    }
}
