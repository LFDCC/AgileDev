using AgileDev.Core.Entity;
using AgileDev.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace AgileDev.Core
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, IEntity
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
        public int Update(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            int result = dbContext.Set<TEntity>().Where(whereExpression).Update(updateExpression);
            return result;
        }

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereExpression)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(whereExpression);
        }

        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereExpression)
        {
            return dbContext.Set<TEntity>().SingleOrDefault(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> whereExpression = null)
        {
            if (whereExpression != null)
            {
                return dbContext.Set<TEntity>().Where(whereExpression);
            }
            else
            {
                return dbContext.Set<TEntity>();
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
        public IQueryable<TEntity> GetPageing(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize, out int total)
        {
            var list = dbContext.Set<TEntity>().Where(whereExpression);

            total = list.Count();

            var paper = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1));

            return paper;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
        
    }
}