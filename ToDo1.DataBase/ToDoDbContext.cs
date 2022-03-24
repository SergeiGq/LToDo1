using Microsoft.EntityFrameworkCore;

namespace ToDo1.DataBase
{
    public class ToDoDbContext: DbContext
    {
        private readonly bool _configure;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!_configure)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=Acab1532;Database=ToDoDb3;");
            }

        }
        public ToDoDbContext(DbContextOptions option) : base(option)
        {
            _configure = true;
            
        }
        public ToDoDbContext()
        {
            
            
                
            
        }
    }
}