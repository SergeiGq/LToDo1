using LToDo1.Models;
using Microsoft.AspNetCore.Mvc;
using ToDo1.DataBase.Models;
using ToDo1.DataBase.Repository;

namespace LToDo1.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ToDoController : ControllerBase
    {


        private readonly ILogger<ToDoController> _logger;
        private readonly ToDoItemRepository _toDoItemRepository;

        public ToDoController(ILogger<ToDoController> logger, ToDoItemRepository toDoItemRepository)
        {
            _logger = logger;
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> Get()
        {
            return await _toDoItemRepository.Get();
        }
        [HttpPost]
        public async Task Post(CreateToDoItemRequest request)
        {
            await _toDoItemRepository.Add(request.Name, request.Description);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _toDoItemRepository.Delete(id);
        }
        [HttpPatch]
        public async Task Patch(Guid id,bool done)
        {
            await _toDoItemRepository.Update(id,done);
        }

    }
}