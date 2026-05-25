using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Data.Abstract;
using GymApp.Entities;

namespace GymApp.Data.Concrete
{
    public class EfCoreWorkoutPlanExerciseDal : EfCoreGenericRepository<WorkoutPlanExercise>, IWorkoutPlanExerciseDal
    {
        public EfCoreWorkoutPlanExerciseDal(AppDbContext context) : base(context)
        {
        }
    }
}
