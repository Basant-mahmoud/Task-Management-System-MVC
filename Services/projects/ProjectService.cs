using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Enum;
using Task_Management_System.Repository.Pro;
using Task = System.Threading.Tasks.Task;
namespace Task_Management_System.Services.projects
{
    public class ProjectService
    {
        private readonly IProjectRepo _ProjectRepo;
        public ProjectService(IProjectRepo projectRepo)
        {
            _ProjectRepo = projectRepo;
        }
        public async Task<int> AddAsync(ProjectDto projectDto)
        {
            try
            {
                Project project = new Project
                {
                    Title = projectDto.Title,
                    Description = projectDto.Description,
                    StartDate = projectDto.StartDate.ToString(),
                    EndDate = projectDto.EndDate.ToString(),
                    Status = projectDto.Status.ToString(),
                    TeamId = projectDto.TeamId
                };
                var result = await _ProjectRepo.AddAsync(project);

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
                existingProject.EndDate = updatedProject.EndDate.ToString();
                existingProject.StartDate = updatedProject.StartDate.ToString();
                existingProject.Status = updatedProject.Status.ToString();
                existingProject.Title = updatedProject.Title;
                existingProject.Description = updatedProject.Description;
                existingProject.TeamId = updatedProject.TeamId;

                var result = await _ProjectRepo.UpdateProjectAsync(existingProject);
                if (result == 0)
                    throw new Exception("Error in Update.");
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
                    Description= project.Description,
                    EndDate= DateTime.Parse(project.EndDate),
                    StartDate= DateTime.Parse(project.StartDate),
                    Status = Enum.Parse<ProjectStatus>(project.Status),
                    TeamId = project.TeamId
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
                var exsitingProject = await _ProjectRepo.GetAsync(id);
                if (exsitingProject == null)
                {
                    throw new KeyNotFoundException("Project not found.");

                }
                var p = new ProjectDto
                {
                    Description = exsitingProject.Description,
                    EndDate = DateTime.Parse(exsitingProject.EndDate),
                    StartDate = DateTime.Parse(exsitingProject.StartDate),
                    Status = Enum.Parse<ProjectStatus>(exsitingProject.Status),
                    TeamId = exsitingProject.TeamId

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
