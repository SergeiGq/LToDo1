
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
            await _toDoItemRepository.Add(request.Name, request.Description, id);
        }

        [HttpDelete]
        [Authorize]
        public async Task Delete(Guid id)
        {
            var userid = Guid.Parse(User.FindFirst("Id").Value);
            await _toDoItemRepository.Delete(id, userid);
        }
        [HttpPatch]
        [Authorize]

        public async Task Patch(Guid id, bool done)
        {
            var userid = Guid.Parse(User.FindFirst("Id").Value);
            await _toDoItemRepository.Update(id, done, userid);
        }

    }
}