using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Service;

public interface IBasketService {
    Task<BasketModel> GetBasket(string userName);
}
