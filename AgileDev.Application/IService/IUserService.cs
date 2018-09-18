using AgileDev.Dto;
using AgileDev.Entity;
using System.Threading.Tasks;

namespace AgileDev.Application.IService
{
    public interface IUserService 
    {
        Task<UserDto> GetUser(int UserId);

        void Delete(UserDto userDto);
    }
}
