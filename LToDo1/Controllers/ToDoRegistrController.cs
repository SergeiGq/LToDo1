using LToDo1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        public async Task<string> Post(ToDoRegistrRequest request)
        {
            var id = await _toDoRegistrRepository.Add(request.Email, request.Password);
            var claims = new List<Claim> { new Claim("Id", id.ToString()) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: "ToDoIssue",
                    audience: "ToDoAud",
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                    signingCredentials: new  SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TweeBank_Secret_Secret_Key_x123daa")), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;

        }
        [HttpPost][Route("Login")]

        public async Task<string> Login(ToDoRegistrRequest request)
        {
            var user = await _toDoRegistrRepository.Get(request.Email, request.Password);
            if (user==null )
            {
                throw new Exception();
            }
            var claims = new List<Claim> { new Claim("Id", user.Id.ToString()) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: "ToDoIssue",
                    audience: "ToDoAud",
                    claims: claims,
                    // как долго токен действует expires
                    expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TweeBank_Secret_Secret_Key_x123daa")), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;

        }
        
        

    }
        
}
