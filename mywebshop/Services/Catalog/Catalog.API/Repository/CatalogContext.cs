using Catalog.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Repository
{
    public interface ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
    }
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly CatalogOptions catalogOptions; 

        public CatalogContext(IOptions<CatalogOptions> options)
        {
            catalogOptions = options.Value;
            var client = new MongoClient(catalogOptions.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(catalogOptions.Database);
                CatalogContextSeed.SeedData(Products);
            }                
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>(catalogOptions.ProductCollection);
            }
        }
    }
}
