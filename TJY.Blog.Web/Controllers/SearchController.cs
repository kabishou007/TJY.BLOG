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
    public class SearchController : Controller
    {
        private IArticleService _articleService;
        public SearchController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        public ActionResult ArticleList(string searchTarget,string keyword,int pageIndex)
        {
            int pageSize = 10;//规定每页加载10篇文章
            int totalNumber;
            List<Article> list;
            switch (searchTarget)
            {
                //首页加载时
                case "resent": list = _articleService.GetResentArticles(pageSize, pageIndex, out totalNumber);
                    break;
                //页面顶部查询时
                case "title": list = _articleService.GetArticlesByTitle(keyword, pageSize, pageIndex, out totalNumber);
                    break;
                //首页按文章分类查询时（点击具体文章分类）
                case "category":
                        int categoryId;
                        int.TryParse(keyword, out categoryId);
                        list = _articleService.GetArticlesByCategoryID(categoryId, pageSize, pageIndex, out totalNumber);
                    break;
                //出鬼了
                default: list = null; 
                    break;
            }
            OperateResult or=new OperateResult();
            if (list==null)
            {
                or.IsSuccess=false;
                or.Data="不知道什么鬼，没找到文章~！";
            }
            else
            {
                or.IsSuccess = true;
                or.Data=PartialView("ArticleList", list);
            }
            return Json(or, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 首页-最新文章列表（第一次加载首页时使用，后续请求用Search/ArticleList）
        /// </summary>
        [ChildActionOnly]
        public ActionResult ResentArticles()
        {
            int totalNumber;
            List<Article> list = _articleService.GetResentArticles(10, 1, out totalNumber);
            return PartialView("ArticleList", list);
        }


        ///// <summary>
        ///// 顶部导航栏的搜索功能
        ///// </summary>
        //public ActionResult Title(string title)
        //{
        //    int totalNumber;
        //    List<Article> list = _articleService.GetArticlesByTitle(title, 10, 1, out totalNumber);
        //    return PartialView("_ArticleList", list);
        //}

        ///// <summary>
        ///// 首页的文章分类具体文章
        ///// </summary>
        //public ActionResult Category(int categoryId) 
        //{
        //    int totalNumber;
        //    List<Article> list = _articleService.GetArticlesByCategoryID(categoryId, 10, 1, out totalNumber);
        //    return PartialView("_ArticleList", list);
        //}

        ///// <summary>
        ///// 最新文章列表
        ///// </summary>
        //[ChildActionOnly]
        //public ActionResult ResentArticles()
        //{
        //    int totalNumber;
        //    List<Article> list=_articleService.GetResentArticles(10,1,out totalNumber);
        //    return PartialView("_ArticleList", list);
        //}
    }
}
