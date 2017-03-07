using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJY.Blog.Web.Filters;

namespace TJY.Blog.Web.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
    }
}
