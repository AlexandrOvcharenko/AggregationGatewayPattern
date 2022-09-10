using Catalog.API.Data.Abstractions;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories;

public class ProductRepository : IProductRepository {
	private readonly ICatalogContext _context;
	public ProductRepository(ICatalogContext context) {
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<Product> GetProduct(string id) {
		return await _context.Products
							.Find(p => p.Id == id)
							.FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Product>> GetProducts() {
		return await _context.Products.Find(p => true).ToListAsync();
	}
}
