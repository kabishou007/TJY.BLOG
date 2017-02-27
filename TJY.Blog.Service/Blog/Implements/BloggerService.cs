using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog.Implements
{
    internal class BloggerService : IBloggerService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public BloggerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public Account GetBloggerInfo()
        {
            return _unitOfWork.GetRepository<Account>().GetList().FirstOrDefault();
        } 
        #endregion
    }
}
