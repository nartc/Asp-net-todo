using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Task.Models;

namespace Task.Persistence
{
    public class MongoDbContext
    {
        private MongoOptions _mongoOptions { get; set; }
        private IMongoDatabase _database { get; }

        public MongoDbContext(IOptions<MongoOptions> _options)
        {
            _mongoOptions = _options.Value;

            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(_mongoOptions.ConnectionString));

                if (_mongoOptions.IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }

                var _mongoClient = new MongoClient(settings);
                _database = _mongoClient.GetDatabase(_mongoOptions.DatabaseName);
            }
            catch (MongoException ex)
            {
                throw new MongoException("Cannot access DB", ex);
            }
        }

        public IMongoCollection<Todo> Todos => _database.GetCollection<Todo>("Todos");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}