using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GymApp.Business.Abstract;
using GymApp.Entities;

namespace GymApp.Web.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutPlanService _workoutPlanService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IExerciseService _exerciseService;
        private readonly IWorkoutPlanExerciseService _workoutPlanExerciseService;
        private readonly IWorkoutSessionService _workoutSessionService;

        public WorkoutController(IWorkoutPlanService workoutPlanService, UserManager<AppUser> userManager, IExerciseService exerciseService, IWorkoutPlanExerciseService workoutPlanExerciseService, IWorkoutSessionService workoutSessionService)
        {
            _workoutPlanService = workoutPlanService;
            _userManager = userManager;
            _exerciseService = exerciseService;
            _workoutPlanExerciseService = workoutPlanExerciseService;
            _workoutSessionService = workoutSessionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var allSessions = await _workoutSessionService.GetAllAsync();
            var myHistory = allSessions
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.Date)
                .ToList();
            ViewBag.History = myHistory;
            return View(myWorkouts);
        }
        [HttpGet]
        public async Task<IActionResult> Tracker(int id)
        {
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var currentRoutine = myWorkouts.FirstOrDefault(w => w.Id == id);

            if (currentRoutine == null)
            {
                return RedirectToAction("Index");
            }

            return View(currentRoutine);
        }
        [HttpPost]
        public async Task<IActionResult> Tracker(decimal FinalVolume, int FinalDuration, string RoutineName, string SessionDetailsJson) 
        {
            var userId = _userManager.GetUserId(User);
            var newSession = new GymApp.Entities.WorkoutSession
            {
                UserId = userId,
                TotalVolume = FinalVolume,
                DurationMinutes = FinalDuration,
                RoutineName = RoutineName ?? "Custom Workout", 
                Date = DateTime.Now,
                SessionDetailsJson = SessionDetailsJson ??"[]"
            };
            await _workoutSessionService.CreateAsync(newSession);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> HistoryDetail(int id)
        {
            var allSessions = await _workoutSessionService.GetAllAsync();
            var session = allSessions.FirstOrDefault(s => s.Id == id);
            if (session == null) return RedirectToAction("Index");

            // Unbox the JSON snapshot!
            List<SavedExercise> details = new List<SavedExercise>();
            if (!string.IsNullOrEmpty(session.SessionDetailsJson))
            {
                details = System.Text.Json.JsonSerializer.Deserialize<List<SavedExercise>>(session.SessionDetailsJson);
            }

            ViewBag.Details = details;
            return View(session);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string routineName)
        {
            if (string.IsNullOrWhiteSpace(routineName))
            {
                return View();
            }

            var userId = _userManager.GetUserId(User);
            var newRoutine = new GymApp.Entities.WorkoutPlan
            {
                Name = routineName,
                UserId = userId
            };
            await _workoutPlanService.CreateAsync(newRoutine);
            return RedirectToAction("Builder", new { id = newRoutine.Id });
        }
        [HttpGet]
        public async Task<IActionResult> Builder(int id)
        {
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var currentRoutine = myWorkouts.FirstOrDefault(w => w.Id == id);
            if (currentRoutine == null)
            {
                return RedirectToAction("Index");
            }
            return View(currentRoutine);
        }
        [HttpGet]
        public async Task<IActionResult> AddExercise(int planId)
        {
            var allExercises =await _exerciseService.GetAll();
            ViewBag.PlanId = planId;
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var currentRoutine = myWorkouts.FirstOrDefault(w => w.Id == planId);
            var existingIds = new List<int>();
            if (currentRoutine != null && currentRoutine.WorkoutPlanExercise != null)
            {
                existingIds = currentRoutine.WorkoutPlanExercise.Select(e => e.ExerciseId).ToList();
            }
            ViewBag.ExistingExerciseIds = existingIds;

            return View(allExercises);
        }
        [HttpPost]
        public async Task<IActionResult> SaveExercisesToPlan(int planId, List<int> selectedExerciseIds)
        {
            if (selectedExerciseIds == null) selectedExerciseIds = new List<int>();

            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var currentRoutine = myWorkouts.FirstOrDefault(w => w.Id == planId);
            if (currentRoutine == null) return RedirectToAction("Index");
            var existingConnections = currentRoutine.WorkoutPlanExercise ?? new List<WorkoutPlanExercise>();
            var existingIds = existingConnections.Select(e => e.ExerciseId).ToList();
            var idsToAdd = selectedExerciseIds.Except(existingIds).ToList();
            foreach (var id in idsToAdd)
            {
                var newConnection = new GymApp.Entities.WorkoutPlanExercise { WorkoutPlanId = planId, ExerciseId = id };
                await _workoutPlanExerciseService.CreateAsync(newConnection);
            }
            var idsToRemove = existingIds.Except(selectedExerciseIds).ToList();
            foreach (var id in idsToRemove)
            {
                var connectionToDelete = existingConnections.FirstOrDefault(c => c.ExerciseId == id);
                if (connectionToDelete != null)
                {
                    await _workoutPlanExerciseService.DeleteAsync(connectionToDelete.Id);
                }
            }
            return RedirectToAction("Builder", new { id = planId });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRoutine(int id)
        {
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var routineToDelete = myWorkouts.FirstOrDefault(w => w.Id == id);

            if (routineToDelete != null)
            {
                await _workoutPlanService.DeleteAsync(routineToDelete.Id);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveExercise(int planId, int exerciseId)
        {
            var userId = _userManager.GetUserId(User);
            var myWorkouts = await _workoutPlanService.GetWorkoutsByUserIdAsync(userId);
            var currentRoutine = myWorkouts.FirstOrDefault(w => w.Id == planId);

            if (currentRoutine != null)
            {
                var connectionToDelete = currentRoutine.WorkoutPlanExercise
                    .FirstOrDefault(wpe => wpe.ExerciseId == exerciseId);

                if (connectionToDelete != null)
                {
                    await _workoutPlanExerciseService.DeleteAsync(connectionToDelete.Id);
                }
            }
            return RedirectToAction("Builder", new { id = planId });
        }
    }
    public class SavedExercise
    {
        public string Name { get; set; }
        public List<SavedSet> Sets { get; set; }
    }
    public class SavedSet
    {
        public decimal Kgs { get; set; }
        public int Reps { get; set; }
    }
}