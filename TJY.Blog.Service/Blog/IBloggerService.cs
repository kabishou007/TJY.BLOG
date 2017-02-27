using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog
{
    public interface IBloggerService:IDependency
    {
        /// <summary>
        /// 获取博主信息
        /// </summary>
        Account GetBloggerInfo();
    }
}
