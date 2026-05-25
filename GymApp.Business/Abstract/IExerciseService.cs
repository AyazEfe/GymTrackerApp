using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAll();
        Task<Exercise?> GetByIdAsync(int id);
        Task CreateAsync(Exercise exercise);
        Task UpdateAsync(Exercise exercise);
        Task DeleteAsync(int id);
    }
}
