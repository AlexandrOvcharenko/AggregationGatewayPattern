using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Service;

public interface ICatalogService {
    Task<CatalogModel> GetCatalog(string id);
}
