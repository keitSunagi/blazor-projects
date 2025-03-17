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

        public void RemoveObject(Todo thisTodo)
        {
            if(thisTodo != null)
            {
                try
                {
                    //Update na tabela que muda o status da tarefa para d de deletado
                    _context.Todos.Where(p => p.Id == thisTodo.Id)
                        .ExecuteUpdateAsync(change => change
                        .SetProperty(e => e.Status, "d"));


                    //adiciona uma audição de deleção para marcar quando foi deletado e o que foi deletado.
                    AuditItem auditionItem = new AuditItem();
                    auditionItem.DeletionDate = DateTime.Today.ToUniversalTime();
                    auditionItem.AuditionId = Guid.NewGuid().ToString();
                    auditionItem.TodoItem = thisTodo;
                    //Adiciona na tabela assincronamente
                    _context.AuditionTodos.AddAsync(auditionItem);

                    _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
