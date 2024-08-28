using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApplicationAPI.Models;
using ToDoApplicationAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApplicationAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;
        public TodoController(IToDoRepository toDoRepository) 
        { 
            _toDoRepository = toDoRepository;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _toDoRepository.GetAll();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            return _toDoRepository.GetById(id);
        }

        // POST api/<TodoController>
        [HttpPost()]
        public void Post([FromBody] ToDo value)
        {
            if(TryValidateModel(value))
            {
                _toDoRepository.Add(value);
            }
        }

        // PUT api/<TodoController>/5
        [HttpPost("complete")]
        public void Complete([FromBody] int id)
        {
            
            _toDoRepository.Complete(id);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _toDoRepository.Delete(id);
        }
    }
}
