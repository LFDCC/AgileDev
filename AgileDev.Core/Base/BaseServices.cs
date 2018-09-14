using AgileDev.Core.EntityFramework;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace AgileDev.Core.Base
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected AgileDevContext dbContext = new AgileDevContext();

        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Add(TEntity t)
        {
            dbContext.Entry(t).State = EntityState.Added;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Delete(TEntity t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Delete(Expression<Func<TEntity, bool>> whereExpression)
        {
            int result = dbContext.Set<TEntity>().Where(whereExpression).Delete();
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Update(TEntity t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            int result =await dbContext.Set<TEntity>().Where(whereExpression).UpdateAsync(updateExpression);
            return result;
        }

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await dbContext.Set<TEntity>().FirstOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await dbContext.Set<TEntity>().SingleOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                return await dbContext.Set<TEntity>().Where(whereExpression).ToListAsync();
            }
            else
            {
                return await dbContext.Set<TEntity>().ToListAsync();
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public async Task<Paging<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize)
        {
            var list = dbContext.Set<TEntity>().Where(whereExpression);

            var total = list.CountAsync();

            var result = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToListAsync();

            var paper = new Paging<TEntity>
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
        /// 执行sql返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            int result = await dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
            return result;
        }

        /// <summary>
        /// 返回IQueryable实体集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetEntities()
        {
            return dbContext.Set<TEntity>();
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return dbContext.SaveChanges();
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}