using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Common;
using TJY.Blog.Web.Models;

namespace TJY.Blog.Web.Filters
{
    public class CustomExceptionAttribute : HandleErrorAttribute
    {
        #region 注入
        private ILogger _logger;
        public CustomExceptionAttribute(ILogger logger)
        {
            _logger = logger;
        }
        #endregion

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            Exception exp = filterContext.Exception;
            //循环获取最里层异常（最里层异常最详细，直观说明了异常原因）
            while (exp.InnerException != null)
            {
                exp = exp.InnerException;
            }
            //记录异常日志
            _logger.LogError(exp,filterContext.HttpContext.Request.Url.ToString());
            //Ajax请求发生异常时,返回错误信息的json
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult jsonResult = new JsonResult();
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jsonResult.Data = new OperateResult()
                {
                    IsSuccess = false,
                    Data = exp.Message
                };
                filterContext.Result = jsonResult;
            }
            //非Ajax请求发生异常时（可以由httpcode继续细化处理，返回不同的错误页）
            else
            {
                filterContext.Result = new ViewResult() { ViewName = "/Views/Shared/Error.cshtml" };
            }
            //通知MVC框架异常已被处理
            filterContext.ExceptionHandled = true;
            //filterContext.HttpContext.Response.Clear();
            //filterContext.HttpContext.Response.StatusCode = 500;
        }
    }
}