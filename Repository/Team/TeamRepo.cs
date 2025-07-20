
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.Team
{
    public class TeamRepo : ITeamRepo
    {
        private readonly TaskManagmentContext _context;
        public TeamRepo(TaskManagmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Models.Team team)
        {
            _context.Teams.Add(team);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Models.Team team)
        {
            _context.Teams.Remove(team);
            return await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Models.Team>> GetAllAsync()
        {
            return await _context.Teams
                 .Include(m => m.Members)
                 .ToListAsync();
        }

        public async Task<Models.Team> GetAsync(int id)
        {
            return await _context.Teams
                .Include(m=>m.Members)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> UpdateProjectAsync(Models.Team team)
        {
            _context.Teams.Update(team);
            return _context.SaveChangesAsync();
        }
        public async Task<List<Models.Team>> GetTeamsByUserIdAsync(int userId)
        {
            var teams = await _context.TeamMembers
                .Where(tm => tm.UserId == userId)
                .Include(tm => tm.Team) // جلب بيانات الفريق
                .Select(tm => tm.Team)
                .ToListAsync();

            return teams;
        }
        public async Task<int> AddMemberToTeam(TeamMember member)
        {
            var addmember = await _context.TeamMembers.AddAsync(member);

            return await _context.SaveChangesAsync();
        }

    }
}
