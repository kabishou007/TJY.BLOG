using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Model;
using TJY.Blog.Service.Admin;
using TJY.Blog.Web.Models;

namespace TJY.Blog.Web.Areas.Admin.Controllers
{
    public class LogController : BaseController
    {
        private ILogAdminService _logAdminService;
        public LogController(ILogAdminService logAdminService)
        {
            _logAdminService = logAdminService;
        }

        /// <summary>
        /// 后台-操作日志查看-主页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 后台-操作日志查看-查询
        /// </summary>
        [HttpPost]
        public ActionResult Search(DatatableParams dtParams)
        {
            DatatableResult dtResult = new DatatableResult();
            int totalNumber = 0;
            switch (dtParams.SearchTarget)
            {
                //最近日志
                case "recent":
                    dtResult.Data = _logAdminService.GetResentLogs(dtParams.Length, dtParams.Start / dtParams.Length + 1, out totalNumber);
                    break;
                //按日期查询时
                case "date": dtResult.Data = _logAdminService.GetLogsByDate(dtParams.SearchWord, dtParams.Length, dtParams.Start / dtParams.Length + 1, out totalNumber);
                    break;
                //出鬼了
                default:
                    dtResult.Data = null;
                    break;
            }
            dtResult.Draw = dtParams.Draw;
            dtResult.RecordsFiltered = totalNumber;
            dtResult.RecordsTotal = totalNumber;
            return Json(dtResult, JsonRequestBehavior.AllowGet);
        }
    }
}
