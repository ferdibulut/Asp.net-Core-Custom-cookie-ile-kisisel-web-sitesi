using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        bool CheckUser(string username,string password);
        AppUser FindByName(string UserName);
    }
}
