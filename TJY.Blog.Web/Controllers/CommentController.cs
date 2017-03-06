using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Service.Blog;
using TJY.Blog.Model;
using TJY.Blog.Web.Models;

namespace TJY.Blog.Web.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// 加载评论
        /// </summary>
        public ActionResult CommentList(int articleId)
        {
            return PartialView("_CommentList",articleId);
        }

        /// <summary>
        /// 评论文章
        /// </summary>
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            OperateResult or = new OperateResult();
            or.IsSuccess=_commentService.AddComment(comment);
            if (or.IsSuccess)//评论成功时，返回新的commentlist给前台刷新
            {
                //TODO:考虑怎么动态刷新评论数
                or.Data=PartialView("_CommentList",comment.ArticleID);
            }
            return Json(or,JsonRequestBehavior.DenyGet);
        }
    }
}
