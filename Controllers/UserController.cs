using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Services.User;

namespace Task_Management_System.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {

            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO userdto)
        {
            
            if (!ModelState.IsValid)
            {
                userdto.CreatedAt = DateTime.Now.ToString();
                var user = await _userService.AddAsync(userdto);

                if (user == null)
                    return NotFound();

                return RedirectToAction("Index");
            }

            return View(userdto); // Return the form with validation errors if any
        }
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View("_Edit", user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserDto userdto)
        {
            var user = await _userService.UpdateAsync(userdto.Id, userdto);
            if (user == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _userService.DeleteAsync(id);
            if (project == 0)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


    }
}
