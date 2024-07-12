namespace Employee.Permissions.Domain.Interfaces.ElasticSearch
{
    public interface ISaveDocumentElasticRepository
    {
        Task<string> AddDocument<T>(T document) where T : class;
    }
}
