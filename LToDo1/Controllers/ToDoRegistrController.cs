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
        private readonly ToDoRegistrRepository _toDoRegistrRepository;
        private readonly Jwtconfig _jwtconfig;
        public ToDoRegistrController(ToDoRegistrRepository toDoItemRepository, Jwtconfig jwtconfig)
        {

            _toDoRegistrRepository = toDoItemRepository;
            this._jwtconfig = jwtconfig;
        }

        [HttpPost]
        public async Task<AuthModel> Post(ToDoRegistrRequest request)
        {
            var id = await _toDoRegistrRepository.Add(request.Email.ToLower(), request.Password);
            var claims = new List<Claim> { new Claim("Id", id.ToString()) };
            // создаем JWT-токен
            string encodedJwt = CreateToken(claims);
            return new AuthModel { Token = encodedJwt };
        }           
            
        [HttpPost]
        [Route("Login")]
        public async Task<AuthModel> Login(ToDoRegistrRequest request)
        {
            var user = await _toDoRegistrRepository.Get(request.Email.ToLower(), request.Password);
            if (user==null )
            {
                throw new Exception();
            }
            var claims = new List<Claim> { new Claim("Id", user.Id.ToString()) };
            // создаем JWT-токен
            string encodedJwt = CreateToken(claims);

            return new AuthModel {Token=encodedJwt };

        }

        private string CreateToken(List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                    issuer: _jwtconfig.ValidIssuer,
                    audience: _jwtconfig.ValidAudience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtconfig.IssuerSigningKey)), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
