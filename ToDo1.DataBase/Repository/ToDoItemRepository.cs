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
        public async Task<IEnumerable<ToDoItem>> Get(Guid userid)
        {
            
            return await _context.ToDoItems!.Where(n=>n.UserId==userid).OrderByDescending(n=>n.CreatedTime).ToListAsync();
        
        }

        public async Task Add(string name, string description, Guid id)
        {
            await _context.ToDoItems!.AddAsync(new ToDoItem
            {

                Id = Guid.NewGuid(),
                Name = name,
                Discription = description,
                Done = false,
                CreatedTime = DateTime.UtcNow,
                ChangedTime = DateTime.UtcNow,
                UserId = id
            }) ;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            ToDoItem customer = new ToDoItem() { Id = id };
            _context.ToDoItems.Attach(customer);
            _context.ToDoItems.Remove(customer);
            await _context.SaveChangesAsync();



        }

        public async Task Update(Guid id, bool done)
        {
            ToDoItem item =await _context.ToDoItems.FirstAsync(n=>n.Id==id);
            
            item.Done = done;
            await _context.SaveChangesAsync();
        }
    }
}
