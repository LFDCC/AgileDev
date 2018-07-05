using Insurance.IDAL;
using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Insurance.DAL
{
    public class BaseDAL : IBaseDAL, IDisposable
    {
        private InsuranceDB DBcontext
        {
            get
            {
                return new InsuranceDB();
            }
        }

        private static BaseDAL _baseDAL;

        private BaseDAL()
        {

        }

        public static BaseDAL GetInstance()
        {
            return _baseDAL ?? (_baseDAL = new BaseDAL());
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add<TEntity>(TEntity t) where TEntity : class
        {
            DBcontext.Entry(t).State = EntityState.Added;
            int result = DBcontext.SaveChanges();
            return result;

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete<TEntity>(TEntity t) where TEntity : class
        {
            DBcontext.Entry(t).State = EntityState.Deleted;
            int result = DBcontext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            int result = DBcontext.Set<TEntity>().Where(whereExpression).Delete();
            return result;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update<TEntity>(TEntity t) where TEntity : class
        {
            DBcontext.Entry(t).State = EntityState.Modified;
            int result = DBcontext.SaveChanges();
            return result;
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
            int result = DBcontext.Set<TEntity>().Where(whereExpression).Update(updateExpression);
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
            return DBcontext.Set<TEntity>().FirstOrDefault(whereExpression);
        }
        /// <summary>
        /// 返回唯一 如果有多个值 则报异常
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereExpression) where TEntity : class
        {
            return DBcontext.Set<TEntity>().SingleOrDefault(whereExpression);
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
                return DBcontext.Set<TEntity>().Where(whereExpression);
            }
            else
            {
                return DBcontext.Set<TEntity>();
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
            var list = DBcontext.Set<TEntity>().Where(whereExpression);

            total = list.Count();

            var paper = list.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1));

            return paper;
        }

        public void Dispose()
        {
            DBcontext.Dispose();
        }
    }
}
