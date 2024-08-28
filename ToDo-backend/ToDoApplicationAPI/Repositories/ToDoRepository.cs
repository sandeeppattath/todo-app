using Microsoft.EntityFrameworkCore;
using ToDoApplicationAPI.Data;
using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

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

        public bool Update(ToDo todo)
        {
            var existing = GetById(todo.Id);
            if (existing != null)
            {
                existing.Title = todo.Title;
                existing.IsCompleted = todo.IsCompleted;

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
