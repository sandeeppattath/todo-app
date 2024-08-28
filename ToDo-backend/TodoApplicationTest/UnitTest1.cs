using Microsoft.EntityFrameworkCore;
using ToDoApplicationAPI.Data;
using ToDoApplicationAPI.Models;
using ToDoApplicationAPI.Repositories;

namespace TodoApplicationTest
{
    public class ToDoRepositoryTests
    {
        private IToDoRepository _repository;

        public ToDoRepositoryTests(IToDoRepository repository)
        { 
            _repository = repository; 
        }


        [Test]
        public void Add_ShouldAddNewTodo()
        {
            // Arrange
            var todo = new ToDo
            {
                Title = "Test ToDo",
                IsCompleted = false
            };

            // Act
            _repository.Add(todo);
            var result = _repository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test ToDo", result.Title);
            Assert.IsFalse(result.IsCompleted);
        }
    }
}