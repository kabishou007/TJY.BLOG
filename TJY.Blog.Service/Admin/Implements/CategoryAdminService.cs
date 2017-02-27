using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Model;
using TJY.Blog.Data;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class CategoryAdminService:ICategoryAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public CategoryAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        #endregion


        #region 实现接口
        public bool AddCategory(Category category)
        {
            _unitOfWork.GetRepository<Category>().Add(category);
            return _unitOfWork.Commit();
        }

        public bool EditCategory(Category category)
        {
            _unitOfWork.GetRepository<Category>().Edit(category);
            return _unitOfWork.Commit();
        }

        public bool DeleteCategory(int categoryID)
        {
            _unitOfWork.GetRepository<Category>().Delete(categoryID);
            return _unitOfWork.Commit();
        }

        public bool BulkDeleteCategories(List<int> categoryIDs)
        {
            foreach (int categoryID in categoryIDs)
            {
                _unitOfWork.GetRepository<Category>().Delete(categoryID);
            }
            return _unitOfWork.Commit();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return _unitOfWork.GetRepository<Category>().Get(categoryID);
        }

        public List<Category> GetCategoriesByName(string categoryName, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Category>().GetPageList(c => c.Name.Contains(categoryName), pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Category> GetAllCategories()
        {
            return _unitOfWork.GetRepository<Category>().GetList().ToList();
        }
        #endregion
    }
}
