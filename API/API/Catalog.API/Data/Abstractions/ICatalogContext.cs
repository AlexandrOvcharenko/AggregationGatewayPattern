using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data.Abstractions;

public interface ICatalogContext {
	IMongoCollection<Product> Products { get; }
}
