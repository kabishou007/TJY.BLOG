using System;
using System.Collections.Generic;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-文章管理服务接口
    /// </summary>
    public interface IArticleManageService : IDependency
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        bool AddArticle(Article article);

        /// <summary>
        /// 发布文章
        /// </summary>
        bool PublishArticle(int articleID);

        /// <summary>
        /// 编辑文章
        /// </summary>
        bool EditArticle(Article article);

        /// <summary>
        /// 根据ID删除文章
        /// </summary>
        bool DeleteArticle(int articleID);

        /// <summary>
        /// 根据Id集合批量删除文章
        /// </summary>
        bool DeleteArticles(List<int> articleIDs);

        /// <summary>
        /// 通过ID查询文章
        /// </summary>
        Article GetArticleByID(int articleID);

        /// <summary>
        /// 获取最新文章列表
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false，即按降序)</param>
        List<Article> GetLatestArticles(int pageSize, int pageIndex, out int totalCount, bool isAsc = false);

        /// <summary>
        /// 通过日期查询文章列表（分页，按日期倒序排序）
        /// </summary>
        /// <param name="startDate">查询开始日期</param>
        /// <param name="endDate">查询结束日期</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false，即按降序)</param>
        List<Article> GetArticlesByDate(DateTime startDate, DateTime endDate, int pageSize, int pageIndex, out int totalCount, bool isAsc = false);

        /// <summary>
        /// 通过文章标题查询文章列表（分页，按日期倒序排列）
        /// </summary>
        /// <param name="title">查询文章标题</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false，即按降序)</param>
        List<Article> GetArticlesByTitle(string title, int pageSize, int pageIndex, out int totalCount, bool isAsc = false);

        /// <summary>
        /// 通过文章类别查询文章列表（分页，按日期倒序排列）
        /// </summary>
        /// <param name="categoryID">查询的类别ID</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false，即按降序)</param>
        List<Article> GetArticlesByCategoryID(int categoryID, int pageSize, int pageIndex, out int totalCount, bool isAsc = false);
    }
}
