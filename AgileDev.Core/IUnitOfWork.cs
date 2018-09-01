using System;

namespace AgileDev.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}