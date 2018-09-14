using AgileDev.Core.Base;
using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Application.App
{
    public abstract class AppServices<TEntity> : IAppServices<TEntity> where TEntity : class
    {
        public IBaseServices<TEntity> baseServices;
        public AppServices()
        {
            if (baseServices == null)
            {
                baseServices = new BaseServices<TEntity>();
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Add(TEntity t)
        {
            baseServices.Add(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Delete(TEntity t)
        {
            baseServices.Delete(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Delete(Expression<Func<TEntity, bool>> whereExpression)
        {
            return baseServices.Delete(whereExpression);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Update(TEntity t)
        {
            baseServices.Update(t);
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
            return await baseServices.UpdateAsync(whereExpression, updateExpression);
        }

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseServices.FirstOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseServices.SingleOrDefaultAsync(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> whereExpression = null)
        {
            return await baseServices.ListAsync(whereExpression);
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
            return await baseServices.GetPagingAsync(whereExpression, pageIndex, pageSize);
        }

        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await baseServices.SaveAsync();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return baseServices.Save();
        }

        /// <summary>
        /// 执行sql查询
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<TElement>> SqlQueryAsync<TElement>(string sql, params object[] parameters)
        {
            return await baseServices.SqlQueryAsync<TElement>(sql,parameters);
        }

        /// <summary>
        /// 执行sql返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await baseServices.ExecuteSqlCommandAsync(sql, parameters);
        }

        /// <summary>
        /// 获取实体的IQueryable对象
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetEntities()
        {
            return baseServices.GetEntities();
        }
    }
}
