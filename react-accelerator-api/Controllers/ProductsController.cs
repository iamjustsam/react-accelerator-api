using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_accelerator_api.Services;

namespace react_accelerator_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.Get();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Product> GetProduct(Guid id)
        {
            var product = _productService.Get(id);

            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public Product CreateProduct(Product client)
        {
            return _productService.Create(client);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<Product> UpdateProduct(Guid id, Product client)
        {
            var newProduct = _productService.Update(id, client);

            return newProduct != null ? Ok(newProduct) : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public void DeleteProduct(Guid id)
        {
            _productService.Delete(id);
        }
    }
}
