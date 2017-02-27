using System;
using System.Collections.Generic;

namespace  TJY.Blog.Data
{
    internal class EFUnitOfWork:IUnitOfWork
    {
        private EFDatabaseContext _context;
        private Dictionary<string, object> _repositoryPool;
        private bool _isDisposed;

        public EFUnitOfWork()
        {
            _context = new EFDatabaseContext();
            _repositoryPool = new Dictionary<string, object>();
            _isDisposed = false;
        }

        /*
         *  用泛型产生对应实体仓储 
         *  为防止同一实体产生多个仓储，新产生的实体仓储以键值对形式存放到仓储池中
         *  每次请求时，先从仓储池中拿，如果没有，则new一个
         *  键用类的全名防止不同命名空间下的重名，值用object类型存放，用时转换
         */
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            string fullNameOfTEntity = typeof(TEntity).FullName;
            object repository;
            if (!_repositoryPool.TryGetValue(fullNameOfTEntity, out repository))
            {
                repository = new EFBaseRepository<TEntity>(_context);
                _repositoryPool.Add(fullNameOfTEntity, repository);
            }
            return repository as EFBaseRepository<TEntity>;
        }
        

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }



        #region Dispose方法
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _isDisposed = true;
        } 
        #endregion

    }
}
