using MMS.Infrastructure;
using System;

namespace MMS.Data
{
    public interface IUnitOfWork:IDependency, IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        bool Commit();

        //void Dispose();
    }
}
