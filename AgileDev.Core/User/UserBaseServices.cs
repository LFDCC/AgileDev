using AgileDev.Core.Base;
using AgileDev.Core.Entities;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Core.User
{
    public class UserBaseServices : BaseServices<T_User>, IUserBaseServices
    {
        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="T_User"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<T_User> FirstOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression)
        {
            return await dbContext.Set<T_User>().FirstOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="T_User"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<T_User> SingleOrDefaultAsync(Expression<Func<T_User, bool>> whereExpression)
        {
            return await dbContext.Set<T_User>().SingleOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T_User"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<T_User>> ListAsync(Expression<Func<T_User, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                return await dbContext.Set<T_User>().Where(whereExpression).ToListAsync();
            }
            else
            {
                return await dbContext.Set<T_User>().ToListAsync();
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T_User"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public async Task<Paging<T_User>> GetPagingAsync(Expression<Func<T_User, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = dbContext.Set<T_User>().Where(whereExpression);

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToListAsync();

            var paper = new Paging<T_User>
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
        /// <summary>
        /// 返回IQueryable集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<T_User> GetAll()
        {
            return dbContext.Set<T_User>();
        }
    }
}