using AgileDev.Entity;
using AgileDev.Interface.IApp;
using AgileDev.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AgileDev.App.Services
{
    public class UserServices : BaseServices<T_User>, IUserServices
    {

        public void Get_User_Test()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateAsync()
        {
            string sql = @"update T_User set CreateTime=GetDate() Where UserId=@UserId";
            var sqlParameter = new SqlParameter("@UserId", 1);
            return await dbContext.Database.ExecuteSqlCommandAsync(sql, sqlParameter);
        }

        public async Task<List<T_User>> GetListAsync()
        {
            string sql = @"select * from T_User Where UserId=@UserId";
            var sqlParameter = new SqlParameter("@UserId", 1);

            List<T_User> users = await dbContext.Database.SqlQuery<T_User>(sql, sqlParameter).ToListAsync();

            return users;
        }
    }
}
