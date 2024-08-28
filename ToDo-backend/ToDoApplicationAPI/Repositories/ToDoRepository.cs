using Microsoft.EntityFrameworkCore;
using ToDoApplicationAPI.Data;
using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoRepository()
        {
        }
        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ToDo> GetAll() => _dbContext.ToDos.ToList();

        public ToDo GetById(int id) => _dbContext.ToDos.FirstOrDefault(t => t.Id == id);

        public void Add(ToDo todo)
        {
            todo.Id = 0;
            todo.IsCompleted = false;
            _dbContext.ToDos.Add(todo);
            _dbContext.SaveChanges();
        }

        public bool Complete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.IsCompleted = true;

                _dbContext.ToDos.Update(existing);
                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _dbContext.ToDos.Remove(existing);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
            
    }
}
