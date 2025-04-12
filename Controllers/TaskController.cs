/*using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class TaskController : Controller
    {
        // controller must be public 
        //cant be static 
        // cant be overload 
        private readonly TaskManagmentContext _context;

        public TaskController(TaskManagmentContext context)
        {
            _context = context;
        }

        public IActionResult index()
        {
            List<Models.Task> model = _context.Tasks.ToList();
            return View("index", model);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTaskDTO taskdto)
        {

            if (!ModelState.IsValid)
            {
                return View(taskdto);
            }
            var newtask = new Models.Task
            {
                Name = taskdto.Name,
                Description = taskdto.Description,
                DueDate = taskdto.DueDate,
                CreatedAt = taskdto.CreatedAt,
                AssignedToId = taskdto.AssignedToId,
                CreatedById = taskdto.CreatedById,
                TaskPriority = taskdto.TaskPriority,
                TaskStatus = taskdto.TaskStatus
            };
            _context.Tasks.Add(newtask);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
*/