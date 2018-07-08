using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.IDAL
{
    public interface IBaseDAL : IDisposable
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Add<TEntity>(TEntity t) where TEntity : class;
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete<TEntity>(TEntity t) where TEntity : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update<TEntity>(TEntity t) where TEntity : class;

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        int Update<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class;

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class;

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> whereExpression = null) where TEntity : class;

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetPageing<TEntity>(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize, out int total) where TEntity : class;
        /// <summary>
        /// SaveChanges提交
        /// </summary>
        /// <returns></returns>
        int Save();
    }


}
