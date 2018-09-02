using AgileDev.Application.App;
using AgileDev.Application.User.Dto;
using AgileDev.Core.Record;
using AgileDev.Core.User;
using AgileDev.Entity;
using System.Collections.Generic;
using System.Linq;

namespace AgileDev.Application.User
{
    public class UserAppServices : AppServices<T_User>, IUserAppServices
    {
        private IUserBaseServices userServices;
        private IRecordBaseServices recordServices;
        public UserAppServices(IUserBaseServices _userServices, IRecordBaseServices _recordServices)
        {
            userServices = _userServices;
            recordServices = _recordServices;
        }
        /// <summary>
        /// 这是测试的方法
        /// </summary>
        public void TestUser()
        {

        }

        public List<User_Record_Dto> user_Record_Dto(string filter0, string filter1)
        {
            var users = userServices.List();
            var records = recordServices.List();

            var list = (from u in users
                        from r in records
                        where u.UserId == r.UserId
                        select new User_Record_Dto { }
                       ).ToList();
            return list;

        }
    }
}
