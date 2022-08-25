namespace TodoAPI.DB;

public record Todo
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool IsComplete { get; set; }
}

public class TodoDB
{
  private static List<Todo> _todos = new List<Todo>()
  {
    new Todo { Id = 1, Name = "Learn C#", IsComplete = true },
    new Todo { Id = 2, Name = "Learn .NET", IsComplete = false },
    new Todo { Id = 3, Name = "Learn Blazor", IsComplete = false },
  };

  public static List<Todo> GetTodos()
  {
    return _todos;
  }

  public static Todo GetTodoById(int id)
  {
    return _todos.SingleOrDefault(t => t.Id == id);
  }

  public static Todo CreateTodo(Todo todo)
  {
    var newTodo = new Todo
    {
      Id = _todos.Max(t => t.Id) + 1,
      Name = todo.Name,
      IsComplete = todo.IsComplete
    };

    _todos.Add(newTodo);

    return newTodo;
  }

  public static Todo UpdateTodo(Todo update)
  {
    _todos = _todos.Select(todo =>
    {
      if (todo.Id == update.Id)
      {
        todo.Name = update.Name;
        todo.IsComplete = update.IsComplete;
      }
      return todo;
    }).ToList();
    return update;
  }

  public static void DeleteTodoById(int id)
  {
    _todos = _todos.Where(todo => todo.Id != id).ToList();
  }


}