using System.Threading.Tasks;
using GymApp.Business.Abstract;
using GymApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWorkoutSessionService _workoutSessionService;
        public HomeController(UserManager<AppUser> userManager, IWorkoutSessionService workoutSessionService)
        {
            _userManager = userManager;
            _workoutSessionService = workoutSessionService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "Account");
            var allSessions = await _workoutSessionService.GetAllAsync();
            var myCompletedSessions = allSessions.Where(s => s.UserId == currentUser.Id).ToList();
            int realWorkoutCount = myCompletedSessions.Count;
            decimal totalVol = myCompletedSessions.Sum(s => s.TotalVolume);
            int totalMins = myCompletedSessions.Sum(s => s.DurationMinutes);
            int totalExpEarned = realWorkoutCount * 150;
            int expNeededPerLevel = 1000;
            int calculatedLevel = (totalExpEarned / expNeededPerLevel) + 1;
            int leftoverExp = totalExpEarned % expNeededPerLevel;
            var stats = new Models.DashboardViewModel
            {
                Name = currentUser.Name ?? "Lifter",
                Level = calculatedLevel,
                CurrentExp = leftoverExp, 
                MaxExp = expNeededPerLevel,
                TotalWorkouts = realWorkoutCount,
                TotalTimeHours = totalMins,
                TotalVolume = totalVol
            };
            return View(stats);
        }
    }
}