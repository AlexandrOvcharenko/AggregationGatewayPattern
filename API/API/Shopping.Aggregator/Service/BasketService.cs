

using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Service;

public class BasketService : IBasketService {
	private readonly HttpClient _httpClient;
	public BasketService(HttpClient httpClient) {
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}

	public async Task<BasketModel> GetBasket(string userName) {
		var response = await _httpClient.GetAsync($"/api/v1/Basket/{userName}");
		return await response.ReadContentAs<BasketModel>();
	}
}
