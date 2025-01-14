﻿using Basket.API.Entities;
using Basket.API.Repositories.Abstactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class BasketController : ControllerBase {
	private readonly IBasketRepository _repository;

	public BasketController(IBasketRepository repository) {
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet("{userName}", Name = "GetBasket")]
	[ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<ShoppingCart>> GetBasket(string userName) {
		var basket = await _repository.GetBasket(userName);
		return Ok(basket ?? new ShoppingCart(userName));
	}

	[HttpPost]
	[ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<ShoppingCart>> UpdateBusket([FromBody] ShoppingCart basket) {
		return Ok(await _repository.UpdateBasket(basket));
	}
}
