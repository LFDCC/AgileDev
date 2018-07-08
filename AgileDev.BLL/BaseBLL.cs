using AgileDev.IBLL;
using AgileDev.IDAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AgileDev.BLL
{
    public class BaseBLL : IBaseBLL
    {
        private IBaseDAL _baseDAL;

        public BaseBLL(IBaseDAL baseDAL)
        {
            _baseDAL = baseDAL;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Add<TEntity>(TEntity t) where TEntity : class
        {
            _baseDAL.Add(t);

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Delete<TEntity>(TEntity t) where TEntity : class
        {
            _baseDAL.Delete(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return _baseDAL.Delete(whereExpression);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public void Update<TEntity>(TEntity t) where TEntity : class
        {
            _baseDAL.Update(t);
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
            return _baseDAL.Update(whereExpression, updateExpression);
        }

        /// <summary>
        /// 返回top1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return _baseDAL.FirstOrDefault(whereExpression);
        }
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return _baseDAL.SingleOrDefault(whereExpression);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> whereExpression = null) where TEntity : class
        {
            return _baseDAL.List(whereExpression);
        }
        /// <summary>
        /// SaveChanges提交到数据库
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _baseDAL.Save();
        }
    }
}
