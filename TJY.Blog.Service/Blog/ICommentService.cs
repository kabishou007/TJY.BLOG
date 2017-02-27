using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog
{
    public interface ICommentService:IDependency
    {
        /// <summary>
        /// 评论
        /// </summary>
        bool AddComment(Comment comment);

        /// <summary>
        /// 通过文章ID获取评论
        /// </summary>
        /// <param name="commentNumber">获取评论数量</param>
        /// <returns></returns>
        List<Comment> GetCommentsByArticleID(int articleID,int commentNumber,int pageIndex,out int totalNumber);

    }
}
