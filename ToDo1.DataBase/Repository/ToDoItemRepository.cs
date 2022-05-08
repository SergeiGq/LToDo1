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

        public async Task Delete(Guid id,Guid userId)
        {
            if (!_context.ToDoItems.Any(n => n.Id == id && n.UserId == userId))
            {
                throw new Exception("no access");
            }
            ToDoItem customer = new ToDoItem() { Id = id,UserId=userId };
            _context.ToDoItems.Attach(customer);
            _context.ToDoItems.Remove(customer);
            await _context.SaveChangesAsync();



        }

        public async Task Update(Guid id, bool done,Guid userid)
        {
            ToDoItem item =await _context.ToDoItems.FirstAsync(n=>n.Id==id&&n.UserId==userid);
            
            item.Done = done;
            await _context.SaveChangesAsync();
        }
    }
}
