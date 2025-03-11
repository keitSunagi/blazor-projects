using EFCoreBlazorAPIStudies.Context;
using EFCoreBlazorAPIStudies.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBlazorAPIStudies.Repositories
{
    public class TodoRepositories
    {
        private readonly TodoContext context;

        public string AddNewTodo(Todo todo)
        {
            string message;
            context.Todos.Add(todo);
            message = SaveDb();
            return message;

        }
        public Todo ReturnTodoById(int id)
        {
            var todo = context.Todos.Where(p => p.id == id);
            return (Todo)todo;
        }
        public List<Todo> GetAllTodos()
        {
            List<Todo> todos = context.Todos.ToList();
            return todos;
           
        }
        public void RemoveTodo(int id)
        {
            
        }
        public string SaveDb()
        {
            string message = "";
            try
            {
                context.SaveChanges();
                message = "Sucesso";
            }
            catch (DbUpdateException ex)
            {
                message = "Erro => " + ex.Message;
            }
            return message;
        }
        public string ModifyTodo(int id, Todo todo)
        {
            return null;
        }

    }
}
