using AgileDev.Core.Base;
using AgileDev.Core.Entities;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Core.Record
{
    public class RecordBaseServices : BaseServices<T_Record>, IRecordBaseServices
    {
        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="T_Record"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<T_Record> FirstOrDefaultAsync(Expression<Func<T_Record, bool>> whereExpression)
        {
            return await dbContext.Set<T_Record>().FirstOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="T_Record"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<T_Record> SingleOrDefaultAsync(Expression<Func<T_Record, bool>> whereExpression)
        {
            return await dbContext.Set<T_Record>().SingleOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T_Record"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<T_Record>> ListAsync(Expression<Func<T_Record, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                return await dbContext.Set<T_Record>().Where(whereExpression).ToListAsync();
            }
            else
            {
                return await dbContext.Set<T_Record>().ToListAsync();
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T_Record"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public async Task<Paging<T_Record>> GetPagingAsync(Expression<Func<T_Record, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = dbContext.Set<T_Record>().Where(whereExpression);

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToListAsync();

            var paper = new Paging<T_Record>
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
        public IQueryable<T_Record> GetAll()
        {
            return dbContext.Set<T_Record>();
        }
    }
}