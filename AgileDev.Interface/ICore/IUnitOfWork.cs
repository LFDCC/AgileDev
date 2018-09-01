using System;

namespace AgileDev.Interface.ICore
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}