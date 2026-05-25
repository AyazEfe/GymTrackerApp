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
    public class WorkoutPlanManager : IWorkoutPlanService
    {
        private readonly IWorkoutPlanDal _workoutPlanDal;
        public WorkoutPlanManager(IWorkoutPlanDal workoutPlanDal)
        {
            _workoutPlanDal = workoutPlanDal;
        }

        public async Task CreateAsync(WorkoutPlan workoutPlan)
        {
            await _workoutPlanDal.CreateAsync(workoutPlan);
        }

        public async Task DeleteAsync(int id)
        {
            var workoutPlanToDelete = await _workoutPlanDal.GetByIdAsync(id);
            if (workoutPlanToDelete != null)
            {
                await _workoutPlanDal.DeleteAsync(workoutPlanToDelete);
            }
        }

        public async Task<List<WorkoutPlan>> GetAllAsync()
        {
            return await _workoutPlanDal.GetAllAsync();
        }

        public async Task<WorkoutPlan?> GetByIdAsync(int id)
        {
            return await _workoutPlanDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkoutPlan workoutPlan)
        {
            await _workoutPlanDal.UpdateAsync(workoutPlan);
        }
        public async Task<List<WorkoutPlan>> GetWorkoutsByUserIdAsync(string userId)
        {
            return await _workoutPlanDal.GetWorkoutsByUserIdAsync(userId);
        }
    }
}
