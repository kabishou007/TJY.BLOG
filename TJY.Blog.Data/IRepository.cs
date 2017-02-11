using System;
using System.Collections.Generic;
using System.Linq;
using MMS.Infrastructure;
using System.Linq.Expressions;

namespace MMS.Data
{
    public interface IRepository<TEntity>:IDependency where TEntity:class
    {
        #region 单体查询
        TEntity Get(object id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> predicate,string[] includeProperties);
        #endregion

        #region 列表查询
        IQueryable<TEntity> GetList();
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate,int number);

        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int number);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int number,string[] includeProperties);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int number);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int number,string[] includeProperties);

        IQueryable<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount);
        IQueryable<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount, string[] includeProperties);

        IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount);

        IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize,int pageIndex,out int totalCount);
        IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount, string[] includeProperties);
        #endregion

        #region 新增
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        #endregion

        #region 删除
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 编辑
        void Edit(TEntity entity);
        void Edit(TEntity entity, string[] changedProperties);
        #endregion
    }
}
