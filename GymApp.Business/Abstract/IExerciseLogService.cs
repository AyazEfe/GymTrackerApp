using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IExerciseLogService
    {
        Task<List<ExerciseLog>> GetAllAsync();
        Task<ExerciseLog?> GetByIdAsync(int id);
        Task CreateAsync(ExerciseLog exerciseLog);
        Task UpdateAsync(ExerciseLog exerciseLog);
        Task DeleteAsync(int id);
    }
}
