using MongoDB.Driver;

namespace ToDo.API.Data
{
    public class ToDoContext : IToDoContext
    {
        public ToDoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Todos = database.GetCollection<Entities.ToDo>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<Entities.ToDo> Todos { get; }
    }
}
