using System.Threading.Tasks;
using GymApp.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GymApp.Web.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<IActionResult> Index()
        {
            var allExercises = await _exerciseService.GetAll();
            return View(allExercises);
        }
    }
}
