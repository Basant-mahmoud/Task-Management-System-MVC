using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;
namespace Task_Management_System.Repository.Pro
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetAsync(int id);
        Task<int> AddProjectAsync(ProjectDto projectDto);
        Task<int> UpdateProjectAsync(Project project);
        Task<int> DeleteAsync(Project project);
    }
}
