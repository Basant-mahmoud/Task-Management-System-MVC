using Task_Management_System.Models;
using Task = System.Threading.Tasks.Task;
namespace Task_Management_System.Repository.Pro
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetAsync(int id);
        Task <int> AddAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteAsync(Project project);
    }
}
