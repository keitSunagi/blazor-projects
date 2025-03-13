using BlazorTodos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BlazorTodos.Data
{
    public class TodoService : ITodoService
    {
        private readonly AppTodoContext _context;

        public TodoService(AppTodoContext context)
        {
            _context = context;
        }
        public void AddNewObject(Todo todo)
        {
            if(todo != null)
            {
                try
                {
                    _context.Todos.Add(todo);
                    _context.SaveChanges();

                }catch(Exception)
                {
                    throw;
                }
            }
            
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            try
            {
                var result = await _context.Todos.ToListAsync();
                if(result == null)
                { 
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<IEnumerable<Todo>> GetTodoByDateRange(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetTodoByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllObjects()
        {
            throw new NotImplementedException();
        }

        public void RemoveObject(string title)
        {
            throw new NotImplementedException();
        }
    }
}
