using MongoDB.Driver;

namespace ToDo.API.Data
{
    public interface IToDoContext
    {
       IMongoCollection<ToDo.API.Entities.ToDo> Todos { get; }
    }
}
