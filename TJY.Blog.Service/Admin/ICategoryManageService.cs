using System.Collections.Generic;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-评论管理服务接口
    /// </summary>
    public interface ICategoryManageService : IDependency
    {
        /// <summary>
        /// 增加文章类别
        /// </summary>
        bool AddCategory(Category category);

        /// <summary>
        /// 修改文章类别
        /// </summary>
        bool EditCategory(Category category);

        /// <summary>
        /// 根据ID删除文章类别
        /// </summary>
        bool DeleteCategory(int categoryID);

        /// <summary>
        /// 通过ID查询评论
        /// </summary>
        Category GetCategoryByID(int categoryID);

        /// <summary>
        /// 通过文章类别名称查询评论列表（分页，按ID排序）
        /// </summary>
        /// <param name="categoryName">文章类别名称</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        List<Category> GetCategoriesByName(string categoryName, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 获得所有类别
        /// </summary>
        List<Category> GetAllCategories();
    }
}
