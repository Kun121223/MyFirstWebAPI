using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    // Chuyển AppDbContext sang đây
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}