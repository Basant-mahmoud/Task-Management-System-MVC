using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Services.projects;

namespace Task_Management_System.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        public async Task<IActionResult> Index()
        {

            var projects = await _projectService.GetAllAsync();
            return View(projects);
        }
        public IActionResult Create()
        {
            var dto = new ProjectDto();
            return PartialView("_CreateProject");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                await _projectService.AddAsync(projectDto);
                return RedirectToAction("Index");
            }
            return View(projectDto);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetAsync(id); // جلب المشروع بناءً على الـ Id
            if (project == null)
            {
                return NotFound();
            }

           // var teams = _projectService.GetTeams();

            // وضع الـ teams في الـ ViewData
           // ViewData["Teams"] = new SelectList(teams, "Id", "Name");

            return PartialView("_EditProject", project); // تمرير المشروع للـ View
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetAsync(id); // جلب المشروع بناءً على الـ Id
            if (project == null)
            {
                return NotFound();
            }

            // var teams = _projectService.GetTeams();

            // وضع الـ teams في الـ ViewData
            // ViewData["Teams"] = new SelectList(teams, "Id", "Name");

            return PartialView("_DetailsProject", project); // تمرير المشروع للـ View
        }
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.DeleteAsync(id); // جلب المشروع بناءً على الـ Id
            if (project == null)
            {
                return NotFound();
            }

            // var teams = _projectService.GetTeams();

            // وضع الـ teams في الـ ViewData
            // ViewData["Teams"] = new SelectList(teams, "Id", "Name");

           // return PartialView("_DetailsProject", project); // تمرير المشروع للـ View
        }


    }
}
