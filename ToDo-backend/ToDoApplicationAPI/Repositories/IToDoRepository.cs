using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        void Add(ToDo todo);
        bool Complete(int todoId);
        bool Delete(int id);
    }
}
