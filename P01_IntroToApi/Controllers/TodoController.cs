using Microsoft.AspNetCore.Mvc;
using P01_IntroToApi.Controllers.Models;

namespace P01_IntroToApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly List<TodoItem> _toDos;

        public TodoController()
        {
            _toDos = new List<TodoItem>
            {
                new TodoItem(1, "Work", "This is the first ToDo", DateTime.Now.AddDays(1), "user1"),
                new TodoItem(2, "Work", "This is the second ToDo", DateTime.Now.AddDays(2), "user2"),
                new TodoItem(3, "Home", "This is the third ToDo", DateTime.Now.AddDays(3), "user3"),
                new TodoItem(4, "Other", "This is the fourth ToDo", DateTime.Now.AddDays(4), "user4"),
                new TodoItem(5, "Office", "This is the fifth ToDo", DateTime.Now.AddDays(5), "user5"),
            };
        }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _toDos;
        }

        //path keitimas GET metodui (relative)
        [HttpGet("GetAllTodoItems")]

        public IEnumerable<TodoItem> GetTodosMetodoR()
        {
            return _toDos;
        }

        //path keitimas GET metodui ir panaikinimas to kas parasyta Controller atribute (absolute, global path)

        [HttpGet("/GetAllTodoItems")]

        public IEnumerable<TodoItem> GetTodosMetodoG()
        {
            return _toDos;
        }

        //metodas kuris grazina viena TodoItem pagal Id
        [HttpGet("{id:int:min(1)}")]
        public TodoItem? Get(int id)
        {
            return _toDos.Find(x => x.Id == id);
        }

        //metodas kuris filtruoja Todo pagal tipa
        [HttpGet("GetByType")]
        public IEnumerable<TodoItem> GetByType(string typeName)
        {
            return _toDos.Where(x => x.Name.Contains(typeName));
        }

        //metodas kuris filtruoja Todo pagal tipa ir grazina viena pagal Id
        [HttpGet("{id:int:min(1)}/GetByType")]
        public TodoItem? GetByTypeAndId([FromQuery]string typeName, [FromRoute] int id)
        {
            return _toDos.Find(x => x.Id == id && x.Name.Contains(typeName));
        }

    }
}
