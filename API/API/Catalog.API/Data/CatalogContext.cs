using Catalog.API.Data.Abstractions;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext : ICatalogContext {
	public CatalogContext(IConfiguration configuration) {
		var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
		var client = new MongoClient(connectionString);
		var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
		var database = client.GetDatabase(databaseName);
		var cllectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName");
		Products = database.GetCollection<Product>(cllectionName);
		CatalogContextSeed.SeedData(Products);
	}

	public IMongoCollection<Product> Products { get; }
}
