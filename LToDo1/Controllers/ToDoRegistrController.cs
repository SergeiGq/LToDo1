using LToDo1.Models;
using Microsoft.AspNetCore.Mvc;
using ToDo1.DataBase.Models;
using ToDo1.DataBase.Repository;

namespace LToDo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoRegistrController : Controller
    {
        public ToDoRegistrController( ToDoRegistrRepository toDoItemRepository)
        {

            _toDoRegistrRepository = toDoItemRepository;
        }

        private readonly ToDoRegistrRepository _toDoRegistrRepository;
        [HttpPost]
        public async Task Post(ToDoRegistrRequest request)
        {
            await _toDoRegistrRepository.Add(request.Email, request.Password);
        }

    }
        
}
