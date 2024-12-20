using Bakery_API.Interfaces;
using Bakery_API.Models;
using Bakery_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productServices;

        public ProductController(IProduct productServices)
        {

            _productServices = productServices;

        }
        [HttpGet("GetAll")]
        public IActionResult GetAllProduct()
        {
            List<dynamic> listProducts = _productServices.GetProducts();

            if (listProducts != null)
            {
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Show product with catelogy",
                    Data = listProducts,

                });

            }
            else
            {
                return Ok(new ResponseServices<List<Product>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<Product>(),

                });

            }
        }
            [Authorize]
        [HttpGet]
        public IActionResult GetByProductCategoryId([FromBody] int productCategoryId)
        {

            List<Product> listProducts = _productServices.GetByProductCategoryId(productCategoryId);

            if (listProducts != null)
            {
                return Ok (new ResponseServices<List<Product>>
                {
                    Success = true,
                    Message = "Show product with catelogy",
                    Data = listProducts,

                });

            }
            else
            {
                return Ok(new ResponseServices<List<Product>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<Product>(),

                });

            }

        }
    }
}
