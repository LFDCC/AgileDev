using AgileDev.Core.Entity;
using AgileDev.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Application.User
{
    public class UserAppServices : AppServices<T_User>, IUserAppServices
    {
        private IUserBaseServices userServices { get; }
        public UserAppServices(IUserBaseServices _userServices)
        {
            userServices = _userServices;
        }
        /// <summary>
        /// 这是测试的方法
        /// </summary>
        public void TestUser()
        {
            throw new NotImplementedException();
        }
    }
}
