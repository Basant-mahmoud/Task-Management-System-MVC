using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Enum;
using Task_Management_System.Repository.Pro;
using Task_Management_System.Services.Teams;
using Task = System.Threading.Tasks.Task;
namespace Task_Management_System.Services.projects
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepo _ProjectRepo;
        private readonly ITeamService _teamService;
        public ProjectService(IProjectRepo projectRepo, ITeamService teamService)
        {
            _ProjectRepo = projectRepo;
            _teamService = teamService;
        }
       

        public async Task<int> AddAsync(ProjectDto projectDto)
        {
            try
            {
                var result = await _ProjectRepo.AddProjectAsync(projectDto);


                if (result == 0)
                    throw new Exception("Error occurred while adding the project.");
                return result;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the project.", ex);
            }
        }
        public async Task<int> UpdateAsync(int id, ProjectDto updatedProject)
        {
            try
            {
                var existingProject = await _ProjectRepo.GetAsync(id);
                if (existingProject == null)
                {
                    throw new KeyNotFoundException("Project not found.");
                }

                existingProject.Title = updatedProject.Title;
                existingProject.Description = updatedProject.Description;
                existingProject.StartDate = updatedProject.StartDate.ToString();
                existingProject.EndDate = updatedProject.EndDate.ToString();
                existingProject.Status = updatedProject.Status.ToString();

                existingProject.ProjectTeams.Clear();

                existingProject.ProjectTeams = updatedProject.TeamIds.Select(team => new ProjectTeam
                {
                    TeamId = team,
                    ProjectId = existingProject.Id  
                }).ToList();

                var result = await _ProjectRepo.UpdateProjectAsync(existingProject);

                if (result == 0)
                    throw new Exception("Error occurred while updating the project.");

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while updating the project.", ex);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var project = await _ProjectRepo.GetAsync(id);
                if (project != null)
                {
                    var result=await _ProjectRepo.DeleteAsync(project);
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
        public async Task<IEnumerable<ProjectDto>>  GetAllAsync()
        {
            try
            {
                var projects= await _ProjectRepo.GetAllAsync();
                if (!projects.Any())
                {
                    return new List<ProjectDto>();
                }
                var projectDto=projects.Select(project=>new ProjectDto
                {
                    Id=project.Id,
                    Description= project.Description,
                    Title=project.Title,
                    EndDate= DateTime.Parse(project.EndDate),
                    StartDate= DateTime.Parse(project.StartDate),
                    Status = Enum.Parse<ProjectStatus>(project.Status),
                    Teams = project.ProjectTeams?.Select(pt => new TeamDto
                    {
                         TeamId = pt.TeamId,
                        Name = pt.Team.Name 
                    }).ToList() ?? new List<TeamDto>()
                }).ToList();
                return projectDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while fetching projects.", ex);
            }
        }
        public async Task<ProjectDto> GetAsync(int id)
        {
            try
            {
                var existingProject = await _ProjectRepo.GetAsync(id);
                if (existingProject == null)
                {
                    throw new KeyNotFoundException("Project not found.");
                }

                var allTeams = (List<TeamDto>)await _teamService.GetAllAsync();

                var selectedTeamIds = existingProject.ProjectTeams?
                    .Select(pt => pt.TeamId)
                    .ToList() ?? new List<int>();

                // علامه للـ TeamDto إنه selected
                foreach (var team in allTeams)
                {
                    if (selectedTeamIds.Contains(team.TeamId))
                        team.IsSelected = true;
                }

                return new ProjectDto
                {
                    Id = existingProject.Id,
                    Title = existingProject.Title,
                    Description = existingProject.Description,
                    StartDate = DateTime.Parse(existingProject.StartDate),
                    EndDate = DateTime.Parse(existingProject.EndDate),
                    Status = Enum.Parse<ProjectStatus>(existingProject.Status),
                    Teams = allTeams,
                    TeamIds = selectedTeamIds
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while fetching projects.", ex);
            }
        }
        public async Task<ProjectDto> GetDetailsAsync(int id)
        {
            try
            {
                var exsitingProject = await _ProjectRepo.GetAsync(id);
                if (exsitingProject == null)
                {
                    throw new KeyNotFoundException("Project not found.");

                }
                var p = new ProjectDto
                {
                    Id = exsitingProject.Id,
                    Title = exsitingProject.Title,
                    Description = exsitingProject.Description,
                    EndDate = DateTime.Parse(exsitingProject.EndDate),
                    StartDate = DateTime.Parse(exsitingProject.StartDate),
                    Status = Enum.Parse<ProjectStatus>(exsitingProject.Status),
                    Teams = exsitingProject.ProjectTeams?.Select(pt => new TeamDto
                    {
                        TeamId = pt.TeamId,
                        Name = pt.Team.Name
                    }).ToList() ?? new List<TeamDto>()
                };
                return p;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while fetching projects.", ex);
            }
        }

    }
}
