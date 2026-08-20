using Microsoft.AspNetCore.Mvc;
using Web.DTOs;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products?searchTerm=Trek&pageIndex=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string? searchTerm, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetProductsAsync(searchTerm, pageIndex, pageSize);
            return Ok(result);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm!" });
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var createdProduct = await _productService.CreateProductAsync(dto);
            // Trả về mã 201 Created cùng đường dẫn lấy chi tiết sản phẩm vừa tạo
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, createdProduct);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var isUpdated = await _productService.UpdateProductAsync(id, dto);
            if (!isUpdated)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm để cập nhật!" });
            }

            return Ok(new { message = "Cập nhật sản phẩm thành công!" });
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm để xóa!" });
            }

            return Ok(new { message = "Xóa sản phẩm thành công!" });
        }
    }
}