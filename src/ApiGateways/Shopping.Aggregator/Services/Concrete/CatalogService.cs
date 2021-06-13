using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services.Concrete
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            _client.GetAsync("/api/v1/Catalog");
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
