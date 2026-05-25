using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Data.Abstract;
using GymApp.Entities;
using Microsoft.EntityFrameworkCore; // <-- The magic tool for .Include()!

namespace GymApp.Data.Concrete
{
    public class EfCoreWorkoutPlanDal : EfCoreGenericRepository<WorkoutPlan>, IWorkoutPlanDal
    {
        private readonly AppDbContext _context;

        public EfCoreWorkoutPlanDal(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<WorkoutPlan>> GetWorkoutsByUserIdAsync(string userId)
        {
            return await _context.WorkoutPlans
                .Include(w => w.WorkoutPlanExercise)
                .ThenInclude(wpe => wpe.Exercise)
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }
    }
}