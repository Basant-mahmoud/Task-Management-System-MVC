using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Services.projects;
using Task_Management_System.Services.Teams;

namespace Task_Management_System.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ITeamService _teamService;

        public ProjectController(IProjectService projectService, ITeamService teamService)
        {
            _projectService = projectService;
            _teamService = teamService;
        }


        public async Task<IActionResult> Index()
        {

            var projects = await _projectService.GetAllAsync();
            return View(projects);
        }
        // for open form
        public async Task<IActionResult> Create()
        {
            var projectDto = new ProjectDto
            {
                Teams = (List<TeamDto>)await _teamService.GetAllAsync()
            };
            return View("_CreateProject", projectDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                await _projectService.AddAsync(projectDto);
                return RedirectToAction("Index");
            }
            projectDto.Teams = (List<TeamDto>)await _teamService.GetAllAsync(); 
            return PartialView("_CreateProject", projectDto);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View("_EditProject", project); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit( ProjectDto projectDto)
        {
            var project = await _projectService.UpdateAsync(projectDto.Id, projectDto); 
            if (project == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        //
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }

           
            return View("_DetailsProject", project); 
        }
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.DeleteAsync(id); // جلب المشروع بناءً على الـ Id
            if (project == 0)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


    }
}
