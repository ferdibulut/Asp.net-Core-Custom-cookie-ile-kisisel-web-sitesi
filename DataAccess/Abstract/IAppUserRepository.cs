using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAppUserRepository:IGenericRepository<AppUser>
    {
        AppUser FindByName(string username);
        bool CheakUser(string username,string password);
    }
}
