using System;

namespace AgileDev.Utiliy.Now
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}