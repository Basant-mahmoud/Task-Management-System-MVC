using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.User
{
    public interface IUserRepo
    {
        Task<int> AddAsync(Models.User user);
        Task<int> UpdateAsync(Models.User user);
        Task<int> DeleteAsync(Models.User user);
        Task<IEnumerable<Models.User>> GetAllAsync();
        Task<Models.User> GetAsync(int id);
        Task<List<TeamWithTasksAndProjectsDto>> GetUserTeamsWithTasksAndProjectsAsync(int userId);

    }
}
