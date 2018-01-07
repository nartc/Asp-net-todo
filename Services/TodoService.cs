using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Task.Models;
using Task.Models.RequestParams;
using Task.Models.ViewModels;
using Task.Repositories;

namespace Task.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        private static string GenerateSlug(string title, string id)
        {
            var lastSix = id.Substring(id.Length - 6);
            var arr = title.ToLower().Split(" ").ToList();
            arr.Add(lastSix);
            return string.Join("-", arr.ToArray());
        }

        public async Task<Todo> CreateTodo(NewTodoParams todoParams)
        {
            var newTodo = new Todo(todoParams);
            newTodo.Id = ObjectId.GenerateNewId().ToString();
            newTodo.Slug = GenerateSlug(newTodo.Title, newTodo.Id);

            var result = await _todoRepository.SaveTodoAsync(newTodo);
            return result;
        }

        public async Task<TodoVm> GetSingleTodo(string slug)
        {
            var todo = await _todoRepository.GetTodoBySlug(slug);
            var result = _mapper.Map<TodoVm>(todo);

            return result;
        }

        public async Task<TodoVm> UpdateTodo(string slug, UpdateTodoParams updatedTodo)
        {
            var currentTodo = await _todoRepository.GetTodoBySlug(slug);

            if (updatedTodo.Title != null)
            {
                updatedTodo.Title = currentTodo.Title;
            }

            if (updatedTodo.Content != null)
            {
                updatedTodo.Content = currentTodo.Content;
            }

            var newTodoParams = new NewTodoParams();
            newTodoParams.Content = updatedTodo.Content;
            newTodoParams.Title = updatedTodo.Title;
            
            var newTodo = new Todo(newTodoParams);
            newTodo.Slug = GenerateSlug(newTodo.Title, newTodo.Id);
            newTodo.CreatedOn = currentTodo.CompletedOn;
            newTodo.UpdatedOn = DateTime.UtcNow;
            newTodo.CompletedOn = updatedTodo.IsCompleted ? DateTime.UtcNow : (DateTime?) null; 

            var todo = await _todoRepository.UpdateTodo(newTodo);
            var result = _mapper.Map<TodoVm>(todo);
            return result;
        }

        public async Task<TodoVm> DeleteTodo(string slug)
        {
            var todo = await _todoRepository.DeleteTodo(slug);
            var result = _mapper.Map<TodoVm>(todo);
            return result;
        }

        public async Task<List<TodoVm>> Get()
        {
            var todos = await _todoRepository.GetTodos();
            var result = _mapper.Map<List<TodoVm>>(todos);
            return result;
        }
    }
}