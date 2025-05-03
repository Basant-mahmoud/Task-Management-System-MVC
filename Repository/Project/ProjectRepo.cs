using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace Task_Management_System.Repository.Pro
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly TaskManagmentContext _context;
        public ProjectRepo(TaskManagmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Project project)
        {
            
            await _context.Projects.AddAsync(project);


            return await _context.SaveChangesAsync(); ;
        }


        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                 /*.Include(p => p.Team)*/
                 .ToListAsync();
        }

        public async Task<Project> GetAsync(int id)
        {
            return await _context.Projects
              /*  .Include(p => p.Team)*/
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
             _context.Projects.Update(project);
            await _context.SaveChangesAsync();

        }
    }
}
