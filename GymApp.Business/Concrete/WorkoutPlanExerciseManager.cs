using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Business.Abstract;
using GymApp.Data.Abstract;
using GymApp.Entities;

namespace GymApp.Business.Concrete
{
    public class WorkoutPlanExerciseManager : IWorkoutPlanExerciseService
    {
        private readonly IWorkoutPlanExerciseDal _workoutPlanExerciseDal;
        public WorkoutPlanExerciseManager (IWorkoutPlanExerciseDal workoutPlanExerciseDal)
        {
            _workoutPlanExerciseDal = workoutPlanExerciseDal;
        }
        public async Task CreateAsync(WorkoutPlanExercise workoutPlanExercise)
        {
            await _workoutPlanExerciseDal.CreateAsync(workoutPlanExercise);
        }

        public async Task DeleteAsync(int id)
        {
            var workoutPlanExerciseToDelete = await _workoutPlanExerciseDal.GetByIdAsync(id);
            if (workoutPlanExerciseToDelete != null)
            {
                await _workoutPlanExerciseDal.DeleteAsync(workoutPlanExerciseToDelete);
            }
        }

        public async Task<List<WorkoutPlanExercise>> GetAllAsync()
        {
            return await _workoutPlanExerciseDal.GetAllAsync();
        }

        public async Task<WorkoutPlanExercise?> GetByIdAsync(int id)
        {
            return await _workoutPlanExerciseDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkoutPlanExercise workoutPlanExercise)
        {
            await _workoutPlanExerciseDal.UpdateAsync(workoutPlanExercise);
        }
    }
}
