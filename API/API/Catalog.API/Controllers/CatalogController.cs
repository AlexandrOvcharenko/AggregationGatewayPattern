using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase {
	private readonly IProductRepository _repository;

	public CatalogController(IProductRepository repository) {
		_repository = repository ?? throw new ArgumentException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
		var products = await _repository.GetProducts();
		return Ok(products);
	}

	[HttpGet("{id:length(24)}", Name = "GetProduct")]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
	public async Task<ActionResult<Product>> GetProductById(string id) {
		var product = await _repository.GetProduct(id);

		if (product == null) {
			return NotFound();
		}

		return Ok(product);
	}
}
