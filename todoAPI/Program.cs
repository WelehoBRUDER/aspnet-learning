using Microsoft.OpenApi.Models;
using TodoAPI.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", builder =>
  {
    builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
  });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1", Description = "Todo list for learning C#." });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
});

app.MapGet("/", () => "Not much to see yet, I'm afraid.");
app.MapGet("/todos/{id}", (int id) => TodoDB.GetTodoById(id));
app.MapGet("/todos", () => TodoDB.GetTodos());
app.MapPost("/todos", (Todo todo) => TodoDB.CreateTodo(todo));
app.MapPut("/todos", (Todo todo) => TodoDB.UpdateTodo(todo));
app.MapDelete("/todos/{id}", (int id) => TodoDB.DeleteTodoById(id));

app.Run();
