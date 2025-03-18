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
                todo.Id = Guid.NewGuid().ToString();
                todo.Status = "v";
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

        public async Task UpdateTodo(Todo todo)
        {
            try
            {
                await _context.Todos.Where(p => p.Id == todo.Id)
                    .ExecuteDeleteAsync();
                await _context.Todos.AddAsync(todo);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveObject(Todo thisTodo)
        {
            if(thisTodo != null)
            {
                try
                {
                    _context.Todos.Where(p => p.Id == thisTodo.Id)
                        .ExecuteDeleteAsync();
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
