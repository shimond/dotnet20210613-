using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Contracts;
using MyWebApp.Models;
using MyWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    //UI
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet(Name ="GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var result = await _productsService.GetAllProducts();
            return Ok(result);
        }


        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var result = await _productsService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost(Name = "AddNewProduct")]
        public async Task<ActionResult<Product>> AddNew(Product p)
        {
            var result = await _productsService.AddNewProduct(p);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult<Product>> DeleteProcuct(int id)
        {
            try
            {
                await _productsService.DeleteProduct(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product p)
        {
            try
            {
                var productWithUpdates = await _productsService.UpdateProduct(id, p);
                return Ok(productWithUpdates);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound();
            }
        }

    }
}
