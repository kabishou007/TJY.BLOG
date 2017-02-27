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
        /// 增加评论-展示
        /// </summary>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 增加评论
        /// </summary>
        [HttpPost]
        public ActionResult Add(Comment comment)
        {
            OperateResult or = new OperateResult();
            or.Result = _commentService.CommentArticleOrReply(comment);
            or.Msg=or.Result?"评论成功":"评论失败了";
            return Json(or, JsonRequestBehavior.DenyGet);
        }


    }
}
