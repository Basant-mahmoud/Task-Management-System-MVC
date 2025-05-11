using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Controllers.DTO;

namespace Task_Management_System.Repository.Pro
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly TaskManagmentContext _context;
        public ProjectRepo(TaskManagmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddProjectAsync(ProjectDto projectDto)
        {
            try
            {
                Project project = new Project
                {
                    Title = projectDto.Title,
                    Description = projectDto.Description,
                    StartDate = projectDto.StartDate.ToString(),
                    EndDate = projectDto.EndDate.ToString(),
                    Status = projectDto.Status.ToString(),
                    ProjectTeams = projectDto.TeamIds.Select(id => new ProjectTeam
                    {
                        TeamId = id
                    }).ToList()
                };

                await _context.Projects.AddAsync(project);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the project.", ex);
            }
        }



        public async Task<int> DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
           return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                 .Include(p => p.Tasks)
                .Include(p => p.ProjectTeams)
                    .ThenInclude(pt => pt.Team)
                        .ThenInclude(t => t.Members)
                            .ThenInclude(m => m.User)
                .ToListAsync();
        }


        public async Task<Project> GetAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.AssignedToUser)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.CreatedByUser)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.Attachments)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.Comments)
                .Include(p => p.ProjectTeams)
                    .ThenInclude(pt => pt.Team)
                        .ThenInclude(t => t.Members)
                            .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> UpdateProjectAsync(Project project)
        {
             _context.Projects.Update(project);
           return await _context.SaveChangesAsync();

        }
    }
}
