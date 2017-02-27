using System.Collections.Generic;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog
{
    public interface ICategoryService:IDependency
    {
        /// <summary>
        /// 获取所有文章类别及相应数量
        /// </summary>
        List<Category> GetCategoryList();
    }
}
