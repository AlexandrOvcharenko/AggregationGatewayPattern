using Basket.API.Entities;
using Basket.API.Repositories.Abstactions;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository {
	private readonly IDistributedCache _cache;

	public BasketRepository(IDistributedCache cache) {
		_cache = cache ?? throw new ArgumentNullException(nameof(cache));
	}

	public async Task<ShoppingCart> GetBasket(string userName) {
		var basket = await _cache.GetStringAsync(userName);
		if (string.IsNullOrEmpty(basket)) {
			basket = null;
		}
		return JsonConvert.DeserializeObject<ShoppingCart>(basket);
	}

	public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket) {
		await _cache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
		return await GetBasket(basket.UserName);

	}
}
