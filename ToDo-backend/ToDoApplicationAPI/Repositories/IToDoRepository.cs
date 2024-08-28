using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        void Add(ToDo todo);
        bool Update(ToDo todo);
        bool Delete(int id);
    }
}
