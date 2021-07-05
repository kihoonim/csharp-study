using book_service.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Data.Services
{
    public class ProductService
    {
        private AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts() => 
            _context.Products.OrderBy(p => p.Name).ToList();

        public Product GetProductById(int id) => 
            _context.Products.FirstOrDefault(p => p.Id == id);

        public IAsyncEnumerable<Product> GetProductsAsync() =>
            _context.Products.OrderBy(p => p.Name).AsAsyncEnumerable();

        public bool TryGetProduct(int id, out Product product)
        {
            product = _context.Products.Find(id);

            return (product != null);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
