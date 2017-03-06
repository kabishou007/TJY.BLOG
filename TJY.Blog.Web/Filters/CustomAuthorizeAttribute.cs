using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Web.Helpers;

namespace TJY.Blog.Web.Filters
{
    /// <summary>
    /// 自定义权限过滤器
    /// 本项目后台仅博主有权限操作，因此本项目权限判定为：
    /// 用户登录后，Session中有BloggerName，则拥有权限进行后台操作
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isLogin = Convert.ToBoolean(SessionHelper.GetSession("IsLogin"));
            #region 验证用户是否登录
            if (!isLogin)
            {
                //filterContext.HttpContext.Response.Write(" <script type='text/javascript'> alert('您还没有登录，或者长时间没有操作了，即将跳转到登录界面！');window.top.location='/'; </script>");
                //filterContext.RequestContext.HttpContext.Response.End();
                //filterContext.Result = new RedirectToRouteResult()
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
                //return;
            }
            #endregion

            //base.OnAuthorization(filterContext);
        }
    }
}