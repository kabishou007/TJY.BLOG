using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TJY.Blog.Model
{
    public class OperationLog
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("日志等级")]
        [Required]
        public string LogLevel { get; set; }

        [DisplayName("操作SQL")]
        [Required]
        public string OperateSQL { get; set; }

        [DisplayName("记录时间")]
        [Required]
        public string LogTime { get; set; }
    }
}
