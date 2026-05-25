using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IWorkoutPlanExerciseService
    {
        Task<List<WorkoutPlanExercise>> GetAllAsync();
        Task<WorkoutPlanExercise?> GetByIdAsync(int id);
        Task CreateAsync(WorkoutPlanExercise workoutPlanExercise);
        Task UpdateAsync(WorkoutPlanExercise workoutPlanExercise);
        Task DeleteAsync(int id);
    }
}
