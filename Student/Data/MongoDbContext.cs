using MongoDB.Driver;
using Student.Models;
using MongoDB.Bson.Serialization.Conventions;
namespace Student.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("StudentManagement");
        }   

        public IMongoCollection<Register> students => _database.GetCollection<Register>("students");
    }
}
