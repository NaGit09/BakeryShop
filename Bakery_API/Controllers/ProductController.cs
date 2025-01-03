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
        [HttpGet("FilterById")]
        public IActionResult FilterById(int id)
        {
            List<dynamic> listProducts = _productServices.FilterById(id);
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
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<dynamic>(),

                });

            }
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
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<dynamic>(),

                });

            }
        }
        [HttpGet("GetByProductCategoryId")]
        public IActionResult GetByProductCategoryId(int categoryId)
        {
            // Kiểm tra tham số đầu vào
            if (categoryId <= 0)
            {
                return BadRequest(new ResponseServices<List<dynamic>>
                {
                    Success = false,
                    Message = "Invalid category ID.",
                    Data = new List<dynamic>()
                });
            }

            // Gọi service để lấy danh sách sản phẩm
            var listProducts = _productServices.GetByProductCategoryId(categoryId);

            if (listProducts != null && listProducts.Any())
            {
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Products found for the category.",
                    Data = listProducts
                });
            }
            else
            {
                return NotFound(new ResponseServices<List<dynamic>>
                {
                    Success = false,
                    Message = "No products found for the category.",
                    Data = new List<dynamic>()
                });
            }
        }
        [HttpGet("GetByGroupProductId")]
        public IActionResult GetByGroupProductId(int GroupProductId)
        {
            List<dynamic> listProducts = _productServices.GetByProductGroupProductId(GroupProductId);

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
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<dynamic>(),

                });

            }
        }
        [HttpGet("SearchProduct")]
        public IActionResult SearchProduct(string input)
        {
            List<dynamic> listProducts = _productServices.SearchProduct(input);

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
                return Ok(new ResponseServices<List<dynamic>>
                {
                    Success = true,
                    Message = "Don't product with catelogy",
                    Data = new List<dynamic>(),

                });

            }
        }
    }
}
