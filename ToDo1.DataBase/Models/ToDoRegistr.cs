using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo1.DataBase.Models
{
    [Index(nameof(Email), IsUnique = true)]
    
    public class ToDoRegistr
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
