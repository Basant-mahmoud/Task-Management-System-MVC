using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.Team
{
    public interface ITeamRepo
    {
        Task<IEnumerable<Models.Team>> GetAllAsync();
        Task<Models.Team> GetAsync(int id);
        Task<int> AddAsync(Models.Team team);
        Task<int> UpdateProjectAsync(Models.Team team);
        Task<int> DeleteAsync(Models.Team team);
        Task<List<Models.Team>> GetTeamsByUserIdAsync(int userId);
        Task<int> AddMemberToTeam(TeamMember member);
    }
}
