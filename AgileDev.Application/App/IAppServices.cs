using AgileDev.Utility.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDev.Application.App
{
    public interface IAppServices<TEntity> where TEntity : class
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Add(TEntity t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete(TEntity t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update(TEntity t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression);
        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression);
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> whereExpression = null);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<Paging<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize);
        /// <summary>
        /// 执行slq查询
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<List<TElement>> SqlQueryAsync<TElement>(string sql, params object[] parameters);
        /// <summary>
        /// 执行sql返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        /// <summary>
        /// 返回IQueryable实体集合
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetEntities();

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        int Save();
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();
    }
}