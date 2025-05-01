using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;

namespace Task_Management_System.Services.projects
{
    public interface  IProjectService
    {
        Task<int> AddAsync(Project project);
        Task UpdateAsync(int id, Project updatedProject);
        Task DeleteAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetAsync(int id);
    }
}
