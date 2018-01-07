using System.Threading.Tasks;
using MongoDB.Driver;
using Task.Models;
using Task.Persistence;

namespace Task.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDbContext _context;

        public UserRepository(MongoDbContext mongoDbContext)
        {
            _context = mongoDbContext;
        }

        public async Task<User> SaveUser(User user)
        {
            await _context.Users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var result = await _context.Users.FindAsync(u => u.Username == username).Result.FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            var result =
                await _context.Users.FindOneAndReplaceAsync(u => u.Username == updatedUser.Username, updatedUser);
            return result;
        }
    }
}