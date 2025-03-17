using BlazorTodos.Models;
using System.Collections;

namespace BlazorTodos.Data
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<IEnumerable<Todo>> GetTodoByTitle(string title);
        Task<IEnumerable<Todo>> GetTodoByDateRange(DateTime initialDate, DateTime finalDate);
        void AddNewObject(Todo todo);
        void RemoveObject(Todo title);
        void RemoveAllObjects();
    }
}
