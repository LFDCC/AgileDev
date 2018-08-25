using AgileDev.Interface.IServices;
using System.Transactions;

namespace AgileDev.Services
{
    /// <summary>
    /// 用于事务操作
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope trans = null;
        public UnitOfWork()
        {
            trans = new TransactionScope();
        }

        public void Commit()
        {
            if (trans != null)
            {
                trans.Complete();
            }
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
            }
        }
    }
}
