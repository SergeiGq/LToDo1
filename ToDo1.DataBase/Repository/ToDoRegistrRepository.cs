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
        

        public async Task Add(string email, string password)
        {
            {
                await _context.ToDoRegistrs!.AddAsync(
                    new ToDoRegistr
                    {
                        Email = email,
                        Password = password
                    });
            }
            await _context.SaveChangesAsync();
        }
    }
}
