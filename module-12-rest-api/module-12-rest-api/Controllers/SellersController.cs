using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using module_12_rest_api.Daos;
using module_12_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace module_12_rest_api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class SellersController : ControllerBase
    {
        private readonly ProductContext _context;

        public SellersController(ProductContext context)
        {
            _context = context;

            if (_context.Sellers.Any()) return;

            ProductSeed.InitData(context);
        }
        // GET: api/<SellersController>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Seller>> GetProducts([FromQuery] string sellerName)
        {
            var result = _context.Sellers as IQueryable<Seller>;

            if (!string.IsNullOrEmpty(sellerName))
            {
                result = result.Where(p => p.SellerName.StartsWith(sellerName, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
            .OrderBy(p => p.SellerId)
            .Take(15));
        }

        // GET api/<SellersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SellersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> PostProduct([FromBody] Seller seller)
        {
            try
            {
                _context.Sellers.Add(seller);
                _context.SaveChanges();

                return new CreatedResult($"/products/{seller.SellerId.ToLower()}", seller);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        // PUT api/<SellersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SellersController>/5
        [HttpDelete]
        [Route("{sellerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> DeleteProduct([FromRoute] string sellerId)
        {
            try
            {
                var sellerList = _context.Sellers as IQueryable<Seller>;
                var seller = sellerList.First(p => p.SellerId.Equals(sellerId));

                _context.Sellers.Remove(seller);
                _context.SaveChanges();

                return new CreatedResult($"/sellers/{seller.SellerId.ToLower()}", seller);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}
