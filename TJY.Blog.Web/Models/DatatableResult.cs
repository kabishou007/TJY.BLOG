using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TJY.Blog.Web.Models
{
    public class DatatableResult
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }

        public DatatableResult()
        {
            Error = "服务器出毛病了~！";
        }
    }
}