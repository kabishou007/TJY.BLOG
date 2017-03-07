using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Model;
using TJY.Blog.Service.Blog;
using TJY.Blog.Web.Models;

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
            _articleService.AddReadNumber(articleId);
            Article article = _articleService.GetArticleByID(articleId);
            return View(article);
        }

        /// <summary>
        /// 点赞
        /// </summary>
        [HttpPost]
        public ActionResult Like(int articleId)
        {
            OperateResult or = new OperateResult();
            or.IsSuccess=_articleService.AddLike(articleId);
            if (or.IsSuccess)
            {
                or.Data = _articleService.GetArticleByID(articleId).Like;
            }
            return Json(or,JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 首页-阅读排行榜
        /// </summary>
        [ChildActionOnly]
        public ActionResult TopReadList()
        {
            List<Article> list = _articleService.GetTopReadArticles(10);
            return PartialView(list);
        }

        


    }
}
