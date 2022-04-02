using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo1.DataBase.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Discription { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ChangedTime { get; set; }

    }
}
