using ToDo.API.Entities;

namespace ToDo.API.Respository
{
    public interface IToDoRepository
    {
        Task AddAsync(ToDo.API.Entities.ToDo toDo);

        Task<IEnumerable<ToDo.API.Entities.ToDo>> GetAllAsync();

        Task<bool> DeleteAsync(string id);

        Task<bool> UpdateAsync(ToDo.API.Entities.ToDo toDo);
    }
}
