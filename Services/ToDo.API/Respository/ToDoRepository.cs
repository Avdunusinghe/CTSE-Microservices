using MongoDB.Driver;
using ToDo.API.Data;

namespace ToDo.API.Respository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IToDoContext _context;

        public ToDoRepository(IToDoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(Entities.ToDo toDo)
        {
            try
            {
                await _context.Todos.InsertOneAsync(toDo);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Entities.ToDo> filter = Builders<Entities.ToDo>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Todos
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Entities.ToDo>> GetAllAsync()
        {
            return await _context.Todos.Find(t=>true).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Entities.ToDo toDo)
        {
            var updateResult = await _context
                                        .Todos
                                        .ReplaceOneAsync(filter: g => g.Id == toDo.Id, replacement: toDo);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
