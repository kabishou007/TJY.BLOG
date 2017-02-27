using System;
using System.Collections.Generic;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-文章管理服务接口
    /// </summary>
    public interface IArticleAdminService : IDependency
    {
        /// <summary>
        /// 暂存文章(文章状态为草稿)
        /// </summary>
        bool SaveArticle(Article article);

        /// <summary>
        /// 改变文章状态
        /// </summary>
        bool PublishArticle(int articleID);

        /// <summary>
        /// 保存并立即发布文章
        /// </summary>
        bool SaveAndPublishArticle(Article article);

        /// <summary>
        /// 编辑文章
        /// </summary>
        bool EditArticle(Article article);

        /// <summary>
        /// 根据ID删除文章(软删除，改变文章状态)
        /// </summary>
        bool DeleteArticle(int articleID);

        /// <summary>
        /// 根据Id集合批量删除文章(软删除，改变文章状态)
        /// </summary>
        bool BulkDeleteArticles(List<int> articleIDs);

        /// <summary>
        /// 通过ID查询文章
        /// </summary>
        Article GetArticleByID(int articleID);

        /// <summary>
        /// 获取最新文章列表（按文章时间降序，用于文章管理首页）
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false，即按降序)</param>
        List<Article> GetResentArticles(int pageSize, int pageIndex, out int totalCount, bool isAsc = false);
        

        /// <summary>
        /// 通过文章标题查询文章列表（分页）
        /// </summary>
        /// <param name="title">查询文章标题</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        List<Article> GetArticlesByTitle(string title, int pageSize, int pageIndex, out int totalCount);

        /// <summary>
        /// 通过文章类别查询文章列表（分页）
        /// </summary>
        /// <param name="categoryID">查询的类别ID</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        List<Article> GetArticlesByCategoryID(int categoryID, int pageSize, int pageIndex, out int totalCount);
    }
}
