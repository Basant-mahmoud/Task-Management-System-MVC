using Task_Management_System.Controllers.DTO;

namespace Task_Management_System.Services.Teams
{
    public interface ITeamService
    {
        Task<int> AddAsync(TeamDto Team);
        Task<int> UpdateAsync(int id, TeamDto updatedTeam);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<TeamDto>> GetAllAsync();
        Task<TeamDto> GetAsync(int id);
        Task<IEnumerable<TeamDto>> GetTeamsByUserIdAsync(int userId);
    }
}
