using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;

namespace GymApp.Business.Abstract
{
    public interface IBodyPartService
    {
        Task<List<BodyPart>> GetAllAsync();
        Task<BodyPart?> GetByIdAsync(int id);
        Task CreateAsync(BodyPart bodyPart);
        Task UpdateAsync(BodyPart bodyPart);
        Task DeleteAsync(int id);
    }
}
