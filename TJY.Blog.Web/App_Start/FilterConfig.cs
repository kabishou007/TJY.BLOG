using System.Web;
using System.Web.Mvc;
using TJY.Blog.Web.Filters;

namespace TJY.Blog.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //注册自定义过滤器
            filters.Add(DependencyResolver.Current.GetService<CustomExceptionAttribute>());
            
        }
    }
}