using Web.DTOs;
using Web.Models;

namespace Web.Services;

public interface IProductService
{
    // 1. Lấy danh sách có tìm kiếm & phân trang
    Task<PagedResultDto<Product>> GetProductsAsync(string? searchTerm, int pageIndex = 1, int pageSize = 10);

    // 2. Lấy chi tiết theo ID
    Task<Product?> GetProductByIdAsync(int id);

    // 3. Thêm mới
    Task<Product> CreateProductAsync(CreateProductDto dto);

    // 4. Sửa
    Task<bool> UpdateProductAsync(int id, UpdateProductDto dto);

    // 5. Xóa
    Task<bool> DeleteProductAsync(int id);
}