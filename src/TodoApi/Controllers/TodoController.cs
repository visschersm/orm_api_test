using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MTech.Domain;
using MTech;
using System.Collections.Generic;

namespace MTech.TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(
            ILogger<TodoController> logger,
            ITodoService todoService
        ) => (_logger, _todoService) = (logger, todoService);

        [HttpGet]
        public IList<TodoItem> GetList()
        {
            return _todoService.GetAll();
        }

        [HttpGet("{id:int}")]
        public TodoItem Get(int id)
        {
            return _todoService.GetById(id);
        }

        [HttpPost]
        public void Create(TodoItem item)
        {
            _todoService.Create(item);
        }

        [HttpPut("{id:int}")]
        public void Update(int id, TodoItem item)
        {
            _todoService.Update(id, item);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _todoService.Delete(id);
        }
    }
}