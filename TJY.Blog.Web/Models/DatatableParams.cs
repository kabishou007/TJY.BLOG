using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TJY.Blog.Web.Models
{
    public class DatatableParams
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchTarget { get; set; }
        public string SearchWord { get; set; }
    }
}