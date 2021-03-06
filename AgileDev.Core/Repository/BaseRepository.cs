﻿using AgileDev.Core.EntityFramework;
using AgileDev.Core.IRepository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace AgileDev.Core.Repository
{
    /// <summary>
    /// 增删改(CUD)操作
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
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
            var result = dbContext.Set<TEntity>().Where(whereExpression).Update(updateExpression);
            return result;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            var result =dbContext.Set<TEntity>().Where(whereExpression).UpdateAsync(updateExpression);
            return result;
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
        public Task<int> SaveAsync()
        {
            var result= dbContext.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}