using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.Models.RequestParams;
using Task.Services;

namespace Task.Controllers
{
    [Route("api/todos")]
    public class TodoController: Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoService.Get();
            return new OkObjectResult(todos);
        }

        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetTodo(string slug)
        {
            var todo = await _todoService.GetSingleTodo(slug);
            return new OkObjectResult(todo);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTodo([FromBody] NewTodoParams todoParams)
        {
            var todo = await _todoService.CreateTodo(todoParams);
            return new OkObjectResult(todo);
        }
    }
}