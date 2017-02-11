using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace MMS.Data
{
    internal class EFBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;
        public EFBaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region 单体查询
        /// <summary>
        /// 根据ID查询单个实体
        /// </summary>
        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// 根据条件查询单个实体
        /// </summary>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 根据条件查询单个实体(包括导航属性)
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="includeProperties">要加载的导航属性</param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate, string[] includeProperties)
        {
            if (includeProperties.Length<=0)
            {
                Get(predicate);
            }
            IQueryable<TEntity> query = _dbSet;
            foreach (string property in includeProperties)
            {
                query = query.Include(property);
            }
            return query.FirstOrDefault(predicate);
        }
        #endregion

        #region 列表查询
        /// <summary>
        /// 查询所有实体
        /// </summary>
        public IQueryable<TEntity> GetList()
        {
            return _dbSet;
        }

        /// <summary>
        /// 查询符合条件的所有实体
        /// </summary>
        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// 按条件查询的分页列表
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        public IQueryable<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);
            totalCount = query.Count();
            pageSize = pageSize <= 0 ? 50 : pageSize;
            //当每页条数多于总条数时，按总条数取出记录
            pageSize = pageSize > totalCount ? totalCount : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            return query.Skip(pageSize * (pageIndex - 1)).Take(pageSize) ;
        }

        /// <summary>
        /// 按条件查询的分页列表(包括导航属性)
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        /// <param name="includeProperties">要加载的导航属性名(列名)</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount, string[] includeProperties)
        {
            if (includeProperties.Length <= 0)
            {
                GetPageList(predicate, pageSize, pageIndex, out totalCount);
            }
            IQueryable<TEntity> query = _dbSet;
            foreach (string property in includeProperties)
            {
                query = query.Include(property);
            }
            query = query.Where(predicate);
            totalCount = query.Count();
            pageSize = pageSize <= 0 ? 50 : pageSize;
            //当每页条数多于总条数时，按总条数取出记录
            pageSize = pageSize > totalCount ? totalCount : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            return query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        /// <summary>
        /// 获得排序列表
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="order">排序条件</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        public IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            IQueryable<TEntity> query = _dbSet;
            totalCount = query.Count();
            pageSize = pageSize <= 0 ? 50 : pageSize;
            //当每页条数多于总条数时，按总条数取出记录
            pageSize = pageSize > totalCount ? totalCount : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            return isAsc ? query.OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize) : query.OrderByDescending(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

       

        /// <summary>
        /// 获取按条件查询的分页排序列表
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        public IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);
            totalCount = query.Count();
            pageSize = pageSize <= 0 ? 50 : pageSize;
            //当每页条数多于总条数时，按总条数取出记录
            pageSize = pageSize > totalCount ? totalCount : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            return isAsc ? query.OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize) : query.OrderByDescending(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        /// <summary>
        /// 获取按条件查询的分页排序列表(包括导航属性)
        /// </summary>
        /// <typeparam name="TOrder">排序列类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="pageSize">每页记录数量</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalCount">总记录数量</param>
        /// <param name="includeProperties">要加载的导航属性名(列名)</param>
        public IQueryable<TEntity> GetPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount, string[] includeProperties)
        {
            if (includeProperties.Length<=0)
            {
                GetPageList(predicate, order, isAsc, pageSize, pageIndex, out totalCount);
            }
            IQueryable<TEntity> query = _dbSet;
            foreach (string property in includeProperties)
            {
                query = query.Include(property);
            }
            query = query.Where(predicate);
            totalCount = query.Count();
            pageSize = pageSize <= 0 ? 50 : pageSize;
            //当每页条数多于总条数时，按总条数取出记录
            pageSize = pageSize > totalCount ? totalCount : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            return isAsc?query.OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize) : query.OrderByDescending(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }
        #endregion

        #region 新增
        /// <summary>
        /// 增加单个实体
        /// </summary>
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            _dbSet.Add(entity);
        }
        /// <summary>
        /// 批量增加实体
        /// </summary>
        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities.Count() <= 0 || entities == null)
            {
                return;
            }
            //_context.Configuration.AutoDetectChangesEnabled = false;
            _dbSet.AddRange(entities);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
        /// <summary>
        /// 根据ID删除单个实体
        /// </summary>
        public void Delete(object id)
        {
            TEntity entity = _dbSet.Find(id);
            Delete(entity);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities.Count() <= 0 || entities == null)
            {
                return;
            }
            //TODO:是否需要先设置实体状态？关联到上下文？
            _dbSet.RemoveRange(entities);
        }
        /// <summary>
        /// 删除符合条件的实体
        /// </summary>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate);
            if (entities.Count() <= 0 || entities == null)
            {
                return;
            }
            else if (entities.Count() == 1)
            {
                Delete(entities.First());
            }
            else
            {
                Delete(entities);
            }
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 更新实体
        /// </summary>
        public void Edit(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 按指定属性(列)更新实体
        /// </summary>
        /// <param name="changedProperties">需要更新的属性名（列名）集合</param>
        public void Edit(TEntity entity, string[] changedProperties)
        {
            if (entity == null)
            {
                return;
            }
            if (changedProperties.Length <= 0)
            {
                Edit(entity);
                return;
            }
            DbEntityEntry entry = _context.Entry(entity);
            entry.State = EntityState.Unchanged;
            foreach (string property in changedProperties)
            {
                entry.Property(property).IsModified = true;
            }
            //关闭EF对于实体的合法性验证参数
            // db.Configuration.ValidateOnSaveEnabled = false;
        }
        #endregion

    }
}
