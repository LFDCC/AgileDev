using AgileDev.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Application.Service
{
    public class UserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }


        
    }
}
