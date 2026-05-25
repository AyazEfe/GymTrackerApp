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
    public class BodyPartManager : IBodyPartService
    {
        private readonly IBodyPartDal _bodyPartDal;
        public BodyPartManager(IBodyPartDal bodyPartDal)
        {
            _bodyPartDal = bodyPartDal;
        }
        public async Task CreateAsync(BodyPart bodyPart)
        {
            await _bodyPartDal.CreateAsync(bodyPart);
        }

        public async Task DeleteAsync(int id)
        {
            var bodyPartToDelete = await _bodyPartDal.GetByIdAsync(id);
            if (bodyPartToDelete != null)
            {
                await _bodyPartDal.DeleteAsync(bodyPartToDelete);
            }
        }

        public async Task<List<BodyPart>> GetAllAsync()
        {
            return await _bodyPartDal.GetAllAsync();
        }

        public async Task<BodyPart?> GetByIdAsync(int id)
        {
            return await _bodyPartDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(BodyPart bodyPart)
        {
            await _bodyPartDal.UpdateAsync(bodyPart);
        }
    }
}
