namespace Task.Persistence
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; } 
        public string DatabaseName { get; set; } 
        public bool IsSSL { get; set; } 
    }
}