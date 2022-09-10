using Shopping.Aggregator.Models;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Service;

public class CatalogService : ICatalogService {
	private readonly HttpClient _httpClient;

	public CatalogService(HttpClient httpClient) {
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}

	public async Task<CatalogModel> GetCatalog(string id) {
		var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
		return await response.ReadContentAs<CatalogModel>();
	}
}
