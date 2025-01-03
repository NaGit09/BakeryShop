using Bakery_API.DTO.AdminDTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using Bakery_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _adminService;
        public AdminController(IAdmin adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _adminService.GetAllProducts();
            return Ok(new ResponseServices<List<ProductDTO>>
            {
                Data = products,
                Success = true,
                Message = "Get all products successfully"
            });
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProduct productDTO)
        {
            if (ModelState.IsValid)
            {
                var addedProduct = await _adminService.AddProductAsync(productDTO);
                return Ok(new ResponseServices<Product>
                {
                    Data = addedProduct,
                    Success = true,
                    Message = "Add product successfully"
                });
            }
            return BadRequest(new ResponseServices<Product>
            {
                Success = false,
                Message = "Add product failed"
            });
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesWithProducts()
        {
            var categories = await _adminService.GetAllCategoriesAsync();
            return Ok(new ResponseServices<List<CategoryWithProductsDTO>>
            {
                Data = categories,
                Success = true,
                Message = "Get all categories successfully"
            });
        }

        [HttpGet("GetAllGroups")]
        public async Task<IActionResult> GetAllGroupsWithProducts()
        {
            var groups = await _adminService.GetAllGroupsAsync();
            return Ok(new ResponseServices<List<GroupWithProductsDTO>>
            {
                Data = groups,
                Success = true,
                Message = "Get all groups successfully"
            });
        }
    }
}
