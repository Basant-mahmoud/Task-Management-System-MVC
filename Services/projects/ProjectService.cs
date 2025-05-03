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
                return await _ProjectRepo.AddAsync(project);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the project.", ex);
            }
        }
        public async Task UpdateAsync(int id, ProjectDto updatedProject)
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

                await _ProjectRepo.UpdateProjectAsync(existingProject);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while updating the project.", ex);
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var project = await _ProjectRepo.GetAsync(id);
                if (project != null)
                {
                    await _ProjectRepo.DeleteAsync(project);

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
       /* public async Task<ProjectDto> GetAsync(int id)
        {
            try
            {
                var result = await _ProjectRepo.GetAsync(id);
                if (result == null)
                {
                    throw new KeyNotFoundException("Project not found.");

                }
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while fetching projects.", ex);
            }
        }*/
    }
}
