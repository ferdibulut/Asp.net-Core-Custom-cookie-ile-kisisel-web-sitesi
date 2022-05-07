using Dapper;
using DataAccess.Abstract;
using DataAccess.Concrete.Dapper;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class DpSocialMediaIconRepository : DpGenericRepository<Entities.Concrete.SocialMediaIcon>, ISocialMediaIconRepository
    {
        private readonly IDbConnection _dbConnection;

        public DpSocialMediaIconRepository(IDbConnection dbConnection):base(dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _dbConnection.Query<SocialMediaIcon>("select * from SocialMediaIcons where AppUserId=@id", new {id=userId}).ToList();
        }
    }
}
