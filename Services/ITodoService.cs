using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Models;
using Task.Models.RequestParams;
using Task.Models.ViewModels;

namespace Task.Services
{
    public interface ITodoService
    {
        Task<Todo> CreateTodo(NewTodoParams todoParams);
        Task<TodoVm> GetSingleTodo(string slug);
        Task<TodoVm> UpdateTodo(string slug, UpdateTodoParams updatedTodo);
        Task<TodoVm> DeleteTodo(string slug);
        Task<List<TodoVm>> Get();
    }
}