using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repositories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> SaveTodoAsync(Todo newTodo);
        Task<Todo> GetTodoBySlug(string slug);
        Task<Todo> DeleteTodo(string slug);
        Task<Todo> UpdateTodo(Todo updatedTodo);
    }
}