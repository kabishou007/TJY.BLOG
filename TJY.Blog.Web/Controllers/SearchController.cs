using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Service.Blog;

namespace TJY.Blog.Web.Controllers
{
    public class SearchController : Controller
    {
        private ICategoryService _categoryService;
        private IArticleService _articleService;
        public SearchController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService=categoryService;
            _articleService = articleService;
        }


        /// <summary>
        /// 首页显示的最新文章
        /// </summary>
        public ActionResult ResentArticles()
        {
            return View();
        }

        /// <summary>
        /// 顶部导航栏的搜索功能
        /// </summary>
        public ActionResult Title()
        {
            return View();
        }

        /// <summary>
        /// 首页的文章分类具体文章
        /// </summary>
        public ActionResult Category() 
        {
            return View();
        }

        
    }
}
