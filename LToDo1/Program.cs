using Microsoft.EntityFrameworkCore;
using ToDo1.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var conectionstring = builder.Configuration.GetConnectionString("default");
builder.Services.AddNpgsql<ToDoDbContext>(conectionstring);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var todoDbContext = scope.ServiceProvider.GetService<ToDoDbContext>();
    todoDbContext.Database.Migrate();
};
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
