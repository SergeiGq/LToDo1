using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo1.DataBase.Models;

namespace ToDo1.DataBase.Repository
{
    public class ToDoRegistrRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRegistrRepository(ToDoDbContext context)
        {
            _context = context;
        }
        

        public async Task<Guid> Add(string email, string password)
        {
            var id = Guid.NewGuid();
                await _context.ToDoRegistrs!.AddAsync(
                    new ToDoRegistr
                    {
                        Id=id,
                        Email = email,
                        Password = password
                    });
            
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<ToDoRegistr> Get(string email, string password)
        {
            return await _context.ToDoRegistrs.FirstOrDefaultAsync(n=>n.Email==email&&n.Password==password);
        }

    }
}
