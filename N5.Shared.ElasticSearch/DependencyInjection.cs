using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.ElasticSearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Shared.ElasticSearch.Persistence;
using Nest;

namespace N5.Shared.ElasticSearch
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:Uri"];
            var defaultIndex = configuration["ELKConfiguration:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            services.AddScoped<ISaveDocumentElasticRepository, SaveDocumentoElasticRepository>();

            CreateIndex(client, defaultIndex);

            return services;
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName, index => index.Map<PermissionEntity>(x => x.AutoMap()));
        }

    }
}
