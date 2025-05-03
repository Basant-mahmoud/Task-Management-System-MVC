using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;

namespace Task_Management_System.Services.projects
{
    public interface  IProjectService
    {
        Task<int> AddAsync(ProjectDto project);
        Task UpdateAsync(int id, ProjectDto updatedProject);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetAsync(int id);
    }
}
