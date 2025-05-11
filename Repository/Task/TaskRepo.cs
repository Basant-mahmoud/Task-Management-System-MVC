using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.Task
{
    public class TaskRepo: ITaskRepo
    {
        private readonly TaskManagmentContext _context;
        public TaskRepo(TaskManagmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Models.Task task)
        {
            _context.Tasks.Add(task);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Models.Task task)
        {
            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            return await _context.Tasks
        .Include(t => t.AssignedToUser)
        .Include(t => t.CreatedByUser)
        .Include(t => t.Project)
        .Include(t => t.Attachments)
        .Include(t => t.Comments)
        .ToListAsync();
        }

        public async Task<Models.Task> GetAsync(int id)
        {
            return await _context.Tasks
               .Include(t => t.AssignedToUser)
        .Include(t => t.CreatedByUser)
        .Include(t => t.Project)
        .Include(t => t.Attachments)
        .Include(t => t.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> UpdateAsync(Models.Task task)
        {
            _context.Tasks.Update(task);
            return _context.SaveChangesAsync();
        }
    }
}
