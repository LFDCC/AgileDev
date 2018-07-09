using AgileDev.DataBase;
using AgileDev.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace AgileDev.DAL
{
    public class BaseDAL : IBaseDAL
    {
        private AgileDevContext _dbContext;

        public BaseDAL(AgileDevContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Add<TEntity>(TEntity t) where TEntity : class
        {
            _dbContext.Entry(t).State = EntityState.Added;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Delete<TEntity>(TEntity t) where TEntity : class
        {
            _dbContext.Entry(t).State = EntityState.Deleted;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            int result = _dbContext.Set<TEntity>().Where(whereExpression).Delete();
            return result;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Update<TEntity>(TEntity t) where TEntity : class
        {
            _dbContext.Entry(t).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression">条件</param>
        /// <param name="updateExpression">表达式</param>
        /// <returns></returns>
        public int Update<TEntity>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class
        {
            int result = _dbContext.Set<TEntity>().Where(whereExpression).Update(updateExpression);
            return result;
        }

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(whereExpression);
        }
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> whereExpression = null) where TEntity : class
        {
            if (whereExpression != null)
            {
                return _dbContext.Set<TEntity>().Where(whereExpression);
            }
            else
            {
                return _dbContext.Set<TEntity>();
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
        public IEnumerable<TEntity> GetPageing<TEntity>(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize, out int total) where TEntity : class
        {
            var list = _dbContext.Set<TEntity>().Where(whereExpression);

            total = list.Count();

            var paper = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1));

            return paper;
        }
        /// <summary>
        /// SaveChanges提交到数据库
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    _dbContext.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BaseDAL() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
