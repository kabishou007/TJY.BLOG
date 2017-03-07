using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Model;
using TJY.Blog.Service.Blog;

namespace TJY.Blog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }


        /// <summary>
        /// 首页-文章分类
        /// </summary>
        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            List<Category> list = _categoryService.GetCategoryList();
            return PartialView(list);
        }

    }
}
