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
    public class WorkoutSessionManager : IWorkoutSessionService
    {
        private readonly IWorkoutSessionDal _workoutSessionDal;
        public WorkoutSessionManager(IWorkoutSessionDal workoutSessionDal)
        {
            _workoutSessionDal = workoutSessionDal;
        }
        public async Task CreateAsync(WorkoutSession workoutSession)
        {
            await _workoutSessionDal.CreateAsync(workoutSession);
        }

        public async Task DeleteAsync(int id)
        {
            var workoutSessionToDelete = await _workoutSessionDal.GetByIdAsync(id);
            if (workoutSessionToDelete != null)
            {
                await _workoutSessionDal.DeleteAsync(workoutSessionToDelete);
            }
        }

        public async Task<List<WorkoutSession>> GetAllAsync()
        {
            return await _workoutSessionDal.GetAllAsync();
        }

        public async Task<WorkoutSession?> GetByIdAsync(int id)
        {
            return await _workoutSessionDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkoutSession workoutSession)
        {
            await _workoutSessionDal.UpdateAsync(workoutSession);
        }
    }
}
