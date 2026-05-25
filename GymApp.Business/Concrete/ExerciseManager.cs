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
    public class ExerciseManager : IExerciseService
    {
        private readonly IExerciseDal _exerciseDal;
        public ExerciseManager(IExerciseDal exerciseDal)
        {
            _exerciseDal = exerciseDal;
        }
        public async Task CreateAsync(Exercise exercise)
        {
            if (string.IsNullOrWhiteSpace(exercise.Name))
            {
                throw new Exception("Exercise name cannot be empty");
            }
            await _exerciseDal.CreateAsync(exercise);
        }

        public async Task DeleteAsync(int id)
        {
            var exerciseToDelete = await _exerciseDal.GetByIdAsync(id);
            if (exerciseToDelete != null)
            {
                await _exerciseDal.DeleteAsync(exerciseToDelete);
            }
        }
     
        public async Task<List<Exercise>> GetAll()
        {
            return await _exerciseDal.GetAllAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _exerciseDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            if (string.IsNullOrWhiteSpace(exercise.Name))
            {
                throw new Exception("Exercise name cannot be empty");
            }
            await _exerciseDal.UpdateAsync(exercise);
        }
    }
}
