using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog
{
    public interface IArticleService:IDependency
    {
        /// <summary>
        /// 通过ID获取文章
        /// </summary>
        Article GetArticleByID(int articleID);

        /// <summary>
        /// 获得首页文章(显示时间最近的文章)
        /// </summary>
        /// <param name="articleNumber">首页文章数量</param>
        List<Article> GetFirstPageArticles(int articleNumber);

        /// <summary>
        /// 获得阅读排行榜文章
        /// </summary>
        /// <param name="articleNumber">阅读排行榜的文章数量</param>
        List<Article> GetTopReadArticles(int articleNumber);

        /// <summary>
        /// 通过文章标题搜索文章(模糊搜索)
        /// </summary>
        List<Article> GetArticlesByTitle(string articleTitle,int articleNumber);

        /// <summary>
        /// 通过文章类别获取文章列表
        /// </summary>
        List<Article> GetArticlesByCategoryID(int categoryID,int articleNumber);
    }
}
