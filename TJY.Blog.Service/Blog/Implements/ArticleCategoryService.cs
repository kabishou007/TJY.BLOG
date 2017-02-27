using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog.Implements
{
    internal class ArticleCategoryService:ICategoryService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public ArticleCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        #endregion


        #region 实现接口
        List<Category> ICategoryService.GetCategoryList()
        {
            return _unitOfWork.GetRepository<Category>().GetList().ToList();
        }
        #endregion

        


        
    }
}
