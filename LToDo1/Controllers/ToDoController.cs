
using LToDo1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        [Authorize]
        public async Task<IEnumerable<ToDoItem>> Get()
        {
            var id = Guid.Parse(User.FindFirst("Id").Value);
            return await _toDoItemRepository.Get(id);
        }
        [HttpPost]
        [Authorize]

        public async Task Post(CreateToDoItemRequest request)
        {
            var id = Guid.Parse(User.FindFirst("Id").Value);
            await _toDoItemRepository.Add(request.Name, request.Description,id);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            var id = Guid.Parse(User.FindFirst("Id").Value);
            await _toDoItemRepository.Delete(id);
        }
        [HttpPatch]
        public async Task Patch(Guid id,bool done)
        {
            await _toDoItemRepository.Update(id,done);
        }

    }
}