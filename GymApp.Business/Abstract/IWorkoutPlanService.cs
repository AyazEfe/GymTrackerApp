using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IWorkoutPlanService
    {
        Task<List<WorkoutPlan>> GetAllAsync();
        Task<WorkoutPlan?> GetByIdAsync(int id);
        Task CreateAsync(WorkoutPlan workoutPlan);
        Task UpdateAsync(WorkoutPlan workoutPlan);
        Task DeleteAsync(int id);
        Task<List<WorkoutPlan>> GetWorkoutsByUserIdAsync(string userId);
    }
}
