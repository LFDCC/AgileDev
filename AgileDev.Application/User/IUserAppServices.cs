using AgileDev.Application.App;
using AgileDev.Application.User.Dto;
using AgileDev.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgileDev.Application.User
{
    public interface IUserAppServices : IAppServices<T_User>
    {
        /// <summary>
        /// 这是测试的方法
        /// </summary>
        Task<List<User_Record_Sql_Dto>> TestUser();

        List<User_Record_Dto> user_Record_Dto(string filter0, string filter1);
    }
}
