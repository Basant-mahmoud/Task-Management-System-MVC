using Task_Management_System.Controllers.DTO;
using Task_Management_System.Repository.Team;
using Task_Management_System.Models;

namespace Task_Management_System.Services.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepo _teamRepo;
        public TeamService(ITeamRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public async Task<int> AddAsync(TeamDto teamDto)
        {
            try
            {
                var t = new Team
                {
                    Name = teamDto.Name,
                    Description = teamDto.Description,
                };

                var result = await _teamRepo.AddAsync(t); 

                if (result == 0)
                    throw new Exception("Error occurred while adding the team.");

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the team.", ex);
            }
        }


        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var team  = await _teamRepo.GetAsync(id);
                if (team != null)
                {
                    var result = await _teamRepo.DeleteAsync(team);
                    if (result == 0)
                        throw new Exception("Error in Delete.");
                    return result;

                }
                else
                {
                    throw new KeyNotFoundException("Project not found.");

                }


            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while deleting the project.", ex);
            }
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _teamRepo.GetAllAsync();
            if (!teams.Any())
            {
                return new List<TeamDto>();
            }
            var teamDto = teams.Select(team => new TeamDto
            {
                TeamId = team.Id,
                Name=team.Name,
                Description=team.Description,
            }
            ).ToList();
            return teamDto;

        }

        public async Task<TeamDto> GetAsync(int id)
        {
            try
            {
                var result = await _teamRepo.GetAsync(id);
                    if (result == null)
                        throw new Exception("Team Not found");
                var Getteam = new TeamDto
                {
                    TeamId = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                };
                return Getteam;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while Getting the team.", ex);
            }
        }

        public async Task<int> UpdateAsync(int id, TeamDto updatedTeam)
        {
            try
            {
                var exsting = await _teamRepo.GetAsync(id);
                if (exsting == null)
                    throw new Exception("Team Not found");
                exsting.Name = updatedTeam.Name;
                exsting.Description = updatedTeam.Description;
                var result = await _teamRepo.UpdateProjectAsync(exsting);
                if (result == 0)
                    throw new Exception("Team Not found");
                return result;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while Updating the team.", ex);
            }


        }
    }
}
