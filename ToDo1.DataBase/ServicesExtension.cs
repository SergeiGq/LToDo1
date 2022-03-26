using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo1.DataBase.Repository;

namespace ToDo1.DataBase
{
    public static class ServicesExtension
    {
        public static void  AddRepository(this IServiceCollection collection)
        {
            collection.AddScoped<ToDoItemRepository>();

        }
    }
}
