using book_service.Data.Models;
using book_service.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace book_service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FormatFilter]
    public class ProductsController : Controller
    {
        private ProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}.{format?}")]
        public Product GetById(int id)
        {
            return _service.GetProductById(id);
        }

        [HttpGet("json/{id}")]
        public JsonResult GetByIdJson(int id)
        {
            var product = _service.GetProductById(id);
            return new JsonResult(product);
        }

        [HttpGet("text/{id}")]
        public ContentResult GetByIdText(int id)
        {
            var product = _service.GetProductById(id);
            return Content(product.ToString());
        }

        [HttpGet("null/{id}")]
        public Product GetByIdNull(int id)
        {
            return null;
        }

        [HttpGet("int/{id}")]
        public int GetByIdint(int id)
        {
            return id;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _service.GetProducts();
        }

        [HttpGet("syncsale")]
        public IEnumerable<Product> GetOnSaleProducts()
        {
            var products = _service.GetProducts();

            foreach (var product in products)
            {
                if (product.IsOnSale)
                {
                    yield return product;
                }
            }
        }

        [HttpGet("asyncsale")]
        public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
        {
            var products = _service.GetProductsAsync();

            await foreach (var product in products)
            {
                if (product.IsOnSale)
                {
                    yield return product;
                }
            }
        }

        [HttpGet("iactionresult/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByIdIActionResult(int id)
        {
            if (!_service.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("iactionresult")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsyncIActionResult(Product product)
        {
            if (product.Description.Contains("XYZ Widget"))
            {
                return BadRequest();
            }

            await _service.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


        [HttpGet("actionresult/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetByIdActionResult(int id)
        {
            if (!_service.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            //return new OkObjectResult(product);
            
            return product;
        }

        [HttpPost("actionresult")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateAsyncActionResult(Product product)
        {
            if (product.Description.Contains("XYZ Widget"))
            {
                return BadRequest();
            }

            await _service.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
