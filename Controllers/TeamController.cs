using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Services.Teams;

namespace Task_Management_System.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var team = await _teamService.GetAllAsync();
            return View(team);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamDto team)
        {
           var teams= await _teamService.AddAsync(team);
            if (teams == null)
                return NotFound();
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _teamService.DeleteAsync(id); 
            if (project == 0)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddMemder()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMemder(AddMemberDto member)
        {
            var teams = await _teamService.AddMemberToTeam(member);
            if (teams == null)
                return NotFound();
            return RedirectToAction("Index");
        }


    }
}
