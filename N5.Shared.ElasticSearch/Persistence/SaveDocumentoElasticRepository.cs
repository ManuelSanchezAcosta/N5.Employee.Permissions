using Employee.Permissions.Domain.Interfaces.ElasticSearch;
using Microsoft.Extensions.Configuration;
using Nest;

namespace N5.Shared.ElasticSearch.Persistence
{
    public class SaveDocumentoElasticRepository : ISaveDocumentElasticRepository
    {
        private readonly ElasticClient _client;
        private readonly IConfiguration _configuration;

        public SaveDocumentoElasticRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            string url = this._configuration["ELKConfiguration:Uri"]!.ToString();
            var defaultIndex = configuration["ELKConfiguration:index"];

            var uri = new Uri(url);

            var settings = new ConnectionSettings(uri)
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            _client = new ElasticClient(settings);
            

        }

        public async Task<string> AddDocument<T>(T document) where T : class
        {
            //return IndexResponse;
            var indexResponse = await _client.IndexDocumentAsync(document);
            return indexResponse.ToString();
        }

    }
}
