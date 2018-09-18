using AgileDev.Application.IService;
using AgileDev.Core.Entities;
using AgileDev.Dto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDev.Application.Service
{
    public class RecordService : BaseService<T_Record>, IRecordService
    {
        public Task<List<UserRecordDto>> GetUserRecordDtos()
        {
            var users = dbContext.Set<T_User>();
            var records = dbContext.Set<T_Record>();
            var ur = (from u in users
                      join r in records on u.UserId equals r.UserId
                      select new UserRecordDto
                      {
                          CreateTime = u.CreateTime,
                          LastLoginTime = u.LastLoginTime,
                          RealName = u.RealName,
                          RecordId = r.RecordId,
                          Remark = r.Remark,
                          Title = r.Title,
                          UserId = u.UserId,
                          UserName = u.UserName
                      }).ToListAsync();
            return ur;
        }
    }
}