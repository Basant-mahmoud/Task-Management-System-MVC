using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
           var model = await _projectService.GetAllAsync();
            return View("Index", model);
        }
    }
}
