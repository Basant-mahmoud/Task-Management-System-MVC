
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.User
{
    public class UserRepo : IUserRepo
    {
        private readonly TaskManagmentContext _context;
        public UserRepo(TaskManagmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Models.User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(Models.User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Models.User>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();


        }

        public async Task<Models.User> GetAsync(int id)
        {
            return  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> UpdateAsync(Models.User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
