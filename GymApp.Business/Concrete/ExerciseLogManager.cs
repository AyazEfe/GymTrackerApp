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
    public class ExerciseLogManager : IExerciseLogService
    {
        private readonly IExerciseLogDal _exerciseLogDal;
        public ExerciseLogManager (IExerciseLogDal exerciseLogDal)
        {
            _exerciseLogDal = exerciseLogDal;
        }
        public async Task CreateAsync(ExerciseLog exerciseLog)
        {
            await _exerciseLogDal.CreateAsync(exerciseLog);
        }

        public async Task DeleteAsync(int id)
        {
            var exerciseLogToDelete = await _exerciseLogDal.GetByIdAsync(id);
            if (exerciseLogToDelete != null)
            {
                await _exerciseLogDal.DeleteAsync(exerciseLogToDelete);
            }
        }

        public async Task<List<ExerciseLog>> GetAllAsync()
        {
            return await _exerciseLogDal.GetAllAsync();
        }

        public async Task<ExerciseLog?> GetByIdAsync(int id)
        {
            return await _exerciseLogDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ExerciseLog exerciseLog)
        {
            await _exerciseLogDal.UpdateAsync(exerciseLog);
        }
    }
}
