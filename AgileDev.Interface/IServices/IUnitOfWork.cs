using System;

namespace AgileDev.Interface.IServices
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
