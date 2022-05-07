using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericRepository<AppUser> _genericRepository;
        private readonly IAppUserRepository _appUserRepository;
        public AppUserManager(IGenericRepository<AppUser> genericRepository, IAppUserRepository appUserRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _appUserRepository = appUserRepository;
        }

        public bool CheckUser(string username, string password)
        {
            return _appUserRepository.CheakUser(username,password);
        }

        public AppUser FindByName(string UserName)
        {
           return _appUserRepository.FindByName(UserName);
        }
    }
}
