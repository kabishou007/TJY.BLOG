using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Model;
using TJY.Blog.Service.Blog;

namespace TJY.Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        private ICommentService _commentService;
        public ArticleController(IArticleService articleService,ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }


        /// <summary>
        /// 文章详情页
        /// </summary>
        public ActionResult Index(int articleId)
        {
            Article article = _articleService.GetArticleByID(articleId);
            return View(article);
        }

        /// <summary>
        /// 加载评论
        /// </summary>
        [HttpGet]
        public ActionResult Comment(int articleId)
        {
            return View();
        }

        /// <summary>
        /// 评论文章
        /// </summary>
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            return View();
        }

        /// <summary>
        /// 点赞
        /// </summary>
        [HttpPost]
        public ActionResult Like(int articleId)
        {
            return View();
        }
    }
}
