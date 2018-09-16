using AgileDev.Core.Entities;
using AgileDev.Core.IRepository;
using AgileDev.Dto;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Core.Repository
{
    public class UserRepository : BaseRepository<T_User>, IUserRepository
    {
        /// <summary>
        /// 返回top1
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<UserDto> FirstOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression)
        {
            T_User t_User = await dbContext.Set<T_User>().FirstOrDefaultAsync(whereExpression);
            UserDto userDto = new UserDto
            {
                CreateTime = t_User.CreateTime,
                LastLoginTime = t_User.LastLoginTime,
                RealName = t_User.RealName,
                UserId = t_User.UserId,
                UserName = t_User.UserName
            };
            return userDto;
        }

        /// <summary>
        ///  返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<UserDto> SingleOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression)
        {
            T_User t_User = await dbContext.Set<T_User>().SingleOrDefaultAsync(whereExpression);
            UserDto userDto = new UserDto
            {
                CreateTime = t_User.CreateTime,
                LastLoginTime = t_User.LastLoginTime,
                RealName = t_User.RealName,
                UserId = t_User.UserId,
                UserName = t_User.UserName
            };
            return userDto;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<UserDto>> ListAsync(Expression<Func<T_User, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                List<UserDto> userDtos = await dbContext.Set<T_User>().Where(whereExpression).Select(t_User => new UserDto
                {
                    CreateTime = t_User.CreateTime,
                    LastLoginTime = t_User.LastLoginTime,
                    RealName = t_User.RealName,
                    UserId = t_User.UserId,
                    UserName = t_User.UserName
                }).ToListAsync();
                return userDtos;
            }
            else
            {
                List<UserDto> userDtos = await dbContext.Set<T_User>().Select(t_User => new UserDto
                {
                    CreateTime = t_User.CreateTime,
                    LastLoginTime = t_User.LastLoginTime,
                    RealName = t_User.RealName,
                    UserId = t_User.UserId,
                    UserName = t_User.UserName
                }).ToListAsync();
                return userDtos;
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Paging<UserDto>> GetPagingAsync(Expression<Func<T_User, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = dbContext.Set<T_User>().Where(whereExpression);

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).Select(t_User => new UserDto
            {
                CreateTime = t_User.CreateTime,
                LastLoginTime = t_User.LastLoginTime,
                RealName = t_User.RealName,
                UserId = t_User.UserId,
                UserName = t_User.UserName
            }).ToListAsync();

            var paper = new Paging<UserDto>
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                total = await total,
                result = await result
            };

            return paper;
        }
        /// <summary>
        /// 执行slq查询
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<TElement>> SqlQueryAsync<TElement>(string sql, params object[] parameters)
        {
            List<TElement> list = await dbContext.Database.SqlQuery<TElement>(sql, parameters).ToListAsync();
            return list;
        }
    }
}