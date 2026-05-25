using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IWorkoutSessionService
    {
        Task<List<WorkoutSession>> GetAllAsync();
        Task<WorkoutSession?> GetByIdAsync(int id);
        Task CreateAsync(WorkoutSession workoutSession);
        Task UpdateAsync(WorkoutSession workoutSession);
        Task DeleteAsync(int id);
    }
}
