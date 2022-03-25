using Microsoft.EntityFrameworkCore;
using ToDo1.DataBase.Models;

namespace ToDo1.DataBase
{
    public class ToDoDbContext: DbContext
    {
        private readonly bool _configure;
        public ToDoDbContext()
        {

        }
        public ToDoDbContext(DbContextOptions option) : base(option)
        {
            _configure = true;

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!_configure)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=Acab1532;Database=ToDoDb3;");
            }

        }

        

    }
}