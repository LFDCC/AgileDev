using AgileDev.Core.Entity;
using AgileDev.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Application.User
{
    public interface IUserAppServices : IAppServices<T_User>
    {
        /// <summary>
        /// 这是测试的方法
        /// </summary>
        void TestUser();
    }
}
