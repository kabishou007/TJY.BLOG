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
        /// 评论文章或回复评论
        /// </summary>
        bool CommentArticleOrReply(Comment comment);
    }
}
