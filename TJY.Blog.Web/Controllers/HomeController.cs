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
        /// <summary>
        /// 博客首页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

    }
}
