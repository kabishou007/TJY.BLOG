using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TJY.Blog.Model
{
    public class ArticleState
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("文章状态")]
        [Required]
        public string Name { get; set; }

        [DisplayName("状态包含文章")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
