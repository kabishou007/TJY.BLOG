using TJY.Blog.Common;
using System;

namespace TJY.Blog.Data
{
    public interface IUnitOfWork:IDependency, IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        bool Commit();

        //void Dispose();
    }
}
