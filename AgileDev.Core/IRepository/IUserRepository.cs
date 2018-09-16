using AgileDev.Core.Entities;
using AgileDev.Dto;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Core.IRepository
{
    public interface IUserRepository : IBaseRepository<T_User>
    {
        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<UserDto> FirstOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression);
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<UserDto> SingleOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<UserDto>> ListAsync(Expression<Func<T_User, bool>> whereExpression = null);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<Paging<UserDto>> GetPagingAsync(Expression<Func<T_User, bool>> whereExpression, int pageIndex, int pageSize);
        /// <summary>
        /// 执行slq查询
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<List<TElement>> SqlQueryAsync<TElement>(string sql, params object[] parameters);
    }
}
