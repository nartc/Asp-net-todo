using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Task.Models;
using Task.Persistence;

namespace Task.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly MongoDbContext _context;

        public TodoRepository(MongoDbContext _mongoContext)
        {
            _context = _mongoContext;
        }

        public async Task<List<Todo>> GetTodos()
        {
            var result = await _context.Todos.FindAsync(t => !(t.CompletedOn.HasValue || !t.CompletedOn.HasValue)).Result
                .ToListAsync();
            return result;
        }

        public async Task<Todo> SaveTodoAsync(Todo newTodo)
        {
            await _context.Todos.InsertOneAsync(newTodo);
            return newTodo;
        }

        public async Task<Todo> GetTodoBySlug(string slug)
        {
            var result = await _context.Todos.FindAsync(t => t.Slug == slug).Result.FirstOrDefaultAsync();
            return result;
        }

        public async Task<Todo> DeleteTodo(string slug)
        {
            var result = await _context.Todos.FindOneAndDeleteAsync(t => t.Slug == slug);
            return result;
        }

        public async Task<Todo> UpdateTodo(Todo updatedTodo)
        {
            var result = await _context.Todos.FindOneAndReplaceAsync(t => t.Slug == updatedTodo.Slug, updatedTodo);
            return result;
        }
    }
}