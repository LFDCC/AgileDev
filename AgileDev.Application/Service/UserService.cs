using AgileDev.Application.IService;
using AgileDev.Core.IRepository;
using AgileDev.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Application.Service
{
    public class UserService: IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public void Delete(UserDto userDto)
        {
            
        }

        public async Task<UserDto> GetUser(int UserId)
        {
            var userDto = await userRepository.SingleOrDefaultAsync(u => u.UserId == UserId);
            
            return userDto;
        }



    }
}
