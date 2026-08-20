using Microsoft.EntityFrameworkCore;
using Web.DTOs;
using Web.Models;

namespace Web.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // 1. Phân trang và tìm kiếm
    public async Task<PagedResultDto<Product>> GetProductsAsync(string? searchTerm, int pageIndex = 1, int pageSize = 10)
    {
        // Khởi tạo truy vấn
        var query = _context.Products.AsQueryable();

        // Nếu có từ khóa tìm kiếm -> Lọc theo tên sản phẩm
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(p => p.ProductName.Contains(searchTerm));
        }

        // Đếm tổng số lượng bản ghi sau khi lọc
        var totalCount = await query.CountAsync();

        // Phân trang: Bỏ qua (Skip) các trang trước và Lấy (Take) số lượng của trang hiện tại
        var items = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResultDto<Product>
        {
            Items = items,
            TotalCount = totalCount,
            PageIndex = pageIndex,
            PageSize = pageSize
        };
    }

    // 2. Lấy chi tiết theo ID
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    // 3. Thêm mới sản phẩm
    public async Task<Product> CreateProductAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            BrandId = dto.BrandId,
            CategoryId = dto.CategoryId,
            ModelYear = dto.ModelYear,
            ListPrice = dto.ListPrice
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    // 4. Cập nhật sản phẩm
    public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        // Gán dữ liệu mới
        product.ProductName = dto.ProductName;
        product.BrandId = dto.BrandId;
        product.CategoryId = dto.CategoryId;
        product.ModelYear = dto.ModelYear;
        product.ListPrice = dto.ListPrice;

        await _context.SaveChangesAsync();
        return true;
    }

    // 5. Xóa sản phẩm
    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}