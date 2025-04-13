using Task_Management_System.Models;
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
        public async Task<int> AddAsync(Project project)
        {
            try
            {
                return await _ProjectRepo.AddAsync(project);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the project.", ex);
            }
        }
        public async Task UpdateAsync(int id, Project updatedProject)
        {
            try
            {
                var existingProject = await _ProjectRepo.GetAsync(id);
                if (existingProject == null)
                {
                    throw new KeyNotFoundException("Project not found.");
                }
                existingProject.EndDate = updatedProject.EndDate;
                existingProject.StartDate = updatedProject.StartDate;
                existingProject.Status = updatedProject.Status;
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
        public async Task<IEnumerable<Project>>  GetAllAsync()
        {
            try
            {
                return await _ProjectRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while fetching projects.", ex);
            }
        }
        public async Task<Project> GetAsync(int id)
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
        }
    }
}
