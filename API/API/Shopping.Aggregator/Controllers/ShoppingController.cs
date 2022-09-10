using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Service;
using System.Net;

namespace Shopping.Aggregator.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ShoppingController : ControllerBase {
	private readonly IBasketService _basketService;
	private readonly ICatalogService _catalogService;

	public ShoppingController(IBasketService basketService, ICatalogService catalogService) {
		_basketService = basketService;
		_catalogService = catalogService;
	}

	[HttpGet("{userName}", Name = "GetShopping")]
	[ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<ShoppingModel>> GetShopping(string userName) {
		var basket = await _basketService.GetBasket(userName);
		foreach (var item in basket.Items) {
			var product = await _catalogService.GetCatalog(item.ProductId);
			item.ProductName = product.Name;
			item.Category = product.Category;
			item.Summary = product.Summary;
			item.Description = product.Description;
			item.ImageFile = product.ImageFile;
		}

		var shoping = new ShoppingModel {
			UserName = userName,
			BasketWithProducts = basket,
		};

		return Ok(shoping);
	}


}
