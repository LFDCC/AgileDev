using AgileDev.Application.App;
using AgileDev.Application.User.Dto;
using AgileDev.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDev.Application.User
{
    public class UserAppServices : AppServices<T_User>, IUserAppServices
    {
        private IAppServices<T_Record> recordServices;
        public UserAppServices(IAppServices<T_Record> _recordServices)
        {
            recordServices = _recordServices;
        }
        /// <summary>
        /// 这是测试的方法
        /// </summary>
        public async Task<List<User_Record_Sql_Dto>> TestUser()
        {
            var result = await SqlQueryAsync<User_Record_Sql_Dto>(@"
                Select * From T_User U 
                Join T_Record R On U.UserId=R.UserId
            ");
            return result;
        }

        public List<User_Record_Dto> user_Record_Dto(string filter0, string filter1)
        {
            var users = GetEntities();
            var records = recordServices.GetEntities();

            var list = (from u in users
                        from r in records
                        where u.UserId == r.UserId
                        select new User_Record_Dto { user = u, record = r }
                       ).ToList();
            return list;

        }
    }
}
