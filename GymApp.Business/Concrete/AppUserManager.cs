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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public async Task CreateAsync(AppUser appUser)
        {
            await _appUserDal.CreateAsync(appUser);
        }

        public async Task DeleteAsync(int id)
        {
            var AppUserToDelete = await _appUserDal.GetByIdAsync(id);
            if (AppUserToDelete != null) { 
            await _appUserDal.DeleteAsync(AppUserToDelete);
            }
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _appUserDal.GetAllAsync();
        }

        public async Task<AppUser?> GetByIdAsync(int id)
        {
            return await _appUserDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AppUser appuser)
        {
            await _appUserDal.UpdateAsync(appuser);
        }
    }
}
