using System;
using System.Collections.Generic;

namespace MMS.Data
{
    internal class EFUnitOfWork:IUnitOfWork
    {
        private DatabaseContext _context;
        private Dictionary<string, object> _repositoryPool;
        private bool _isDisposed;

        public UnitOfWork()
        {
            _context = new DatabaseContext();
            //_context = context;
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
            //StringBuilder sbSQL = new StringBuilder();
            ////Database.Log属性为Action委托属性，指向一个方法。
            ////EF会在一次数据库操作中，多次调用这个委托方法，可以记录执行的SQL语句，执行开始时间，执行结果，生成的查询参数等内容
            //_context.Database.Log = (text) =>{sbSQL.Append(text);};
            //_context.SaveChanges();
            //int userID = ((SessionUser)SessionHelper.GetSession("CurrentUser")).UserID;
            //string operateSQL = sbSQL.ToString();
            ////Logger.LogOperation(userID, operateSQL);
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
