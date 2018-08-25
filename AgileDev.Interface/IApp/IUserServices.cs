using AgileDev.Interface.IServices;
using AgileDev.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AgileDev.Interface.IApp
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUserServices: IBaseServices<T_User>
    {
        void Get_User_Test();
        
        Task<int> UpdateAsync();

        Task<List<T_User>> GetListAsync();
    }
}
