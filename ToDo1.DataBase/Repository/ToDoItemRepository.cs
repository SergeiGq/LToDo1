using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo1.DataBase.Models;

namespace ToDo1.DataBase.Repository
{
    public class ToDoItemRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoItemRepository(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoItem>> Get()
        {
            return await _context.ToDoItems!.ToListAsync();
        }

        public async Task Add(string name, string description)
        {
           await _context.ToDoItems!.AddAsync(new ToDoItem
            {
                
                Id = Guid.NewGuid(),
                Name = name,
                Discription = description,
                Done = false,
                CreatedTime = DateTime.UtcNow,
                ChangedTime = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }
    }
}
