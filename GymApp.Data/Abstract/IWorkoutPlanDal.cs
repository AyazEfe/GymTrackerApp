using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Data.Abstract
{
    public interface IWorkoutPlanDal : IRepository<WorkoutPlan>
    {
        Task<List<WorkoutPlan>> GetWorkoutsByUserIdAsync(string userId);
    }
}
