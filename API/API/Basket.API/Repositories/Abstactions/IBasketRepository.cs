using Basket.API.Entities;

namespace Basket.API.Repositories.Abstactions;

public interface IBasketRepository {
    Task<ShoppingCart> GetBasket(string userName);
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
}
