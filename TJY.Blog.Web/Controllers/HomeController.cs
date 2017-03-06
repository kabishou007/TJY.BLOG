using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Model;
using TJY.Blog.Service.Blog;

namespace TJY.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        //private ICategoryService _categoryService;
        //private IArticleService _articleService;
        //public HomeController(ICategoryService categoryService,IArticleService articleService)
        //{
        //    _categoryService=categoryService;
        //    _articleService = articleService;
        //}

        /// <summary>
        /// 博客首页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        

    }
}
