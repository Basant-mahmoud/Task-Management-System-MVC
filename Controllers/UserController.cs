/*using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class UserController : Controller
    {
        readonly TaskManagmentContext _context;
        public UserController(TaskManagmentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<User> usersmodel = _context.Users.ToList();
            return View(usersmodel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserDTO userdto)
        {

            if (!ModelState.IsValid)
            {
                return View(userdto);
            }
            var newuser = new User
            {
                Name= userdto.Name

            };
            _context.Users.Add(newuser);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
*/