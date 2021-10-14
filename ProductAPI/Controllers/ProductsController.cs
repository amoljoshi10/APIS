using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DemoAPI.Interfaces;


namespace DemoAPI.Controllers
{
    [ApiController]
    //[Route("[api/products]")]
    //[Route("api/[controller]")]
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        //private readonly ILogger<ProductController> _logger;

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //public ProductController(ILogger<ProductController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }
        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        {

            Request.Headers.TryGetValue("x-security-header", out var headerValue);

            // read your secret from Azure Key Vault
            string kvUri =
                    "https://kv-for-apim.vault.azure.net/";

            SecretClient client =
                new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret= client.GetSecretAsync("securityHeader").Result.Value.Value;

            if (!headerValue.Equals(secret))
                return Unauthorized("Direct Access to API is restricted");

            var product=_productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _productService.AddProduct(product);

            return Created("products/{product.ProductID}", product);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productEntity = _productService.GetProductById(productId);
            if (productEntity == null)
            {
                return NotFound();
            }
            
            _productService.UpdateProduct(productEntity, product);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var productEntity = _productService.GetProductById(productId);
            if (productEntity == null)
            {
                return NotFound();
            }
            _productService.DeletProduct(productEntity);
            return Ok(true);
        }

        [HttpGet("{kvname}/{secret}")]
        public string GetSecretsAndKeys(string kvname,string secret)
        {
            // read your secret from Azure Key Vault
            string kvUri =
                    "https://kv-for-apim.vault.azure.net/";

            SecretClient client =
                new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            return client.GetSecretAsync(secret).Result.Value.Value;
        }


    }
}
