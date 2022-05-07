using Dapper;
using DataAccess.Abstract;
using DataAccess.Concrete.Dapper;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Concrete
{
    public class DbAppUserRepository:DpGenericRepository<AppUser>,IAppUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public DbAppUserRepository(IDbConnection dbConnection):base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool CheakUser(string username, string password)
        {
           var user= _dbConnection.QueryFirstOrDefault<AppUser>("Select * from AppUsers where Username=@username and Password=@password",new {username=username,password=password});
            return user != null;
        }

        public AppUser FindByName(string userName)
        {   
           return _dbConnection.QueryFirstOrDefault<AppUser>("select * from AppUsers where UserName=@username", new { userName = userName });
        }
    }
}
