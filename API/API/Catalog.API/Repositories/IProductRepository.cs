using Catalog.API.Entities;

namespace Catalog.API.Repositories;

public interface IProductRepository {
	Task<IEnumerable<Product>> GetProducts();
	Task<Product> GetProduct(string id);
}
