 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJY.Blog.Model
{
    public class Article
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }

        [DisplayName("内容")]
        [Required]
        public string Content { get; set; }

        [DisplayName("文章创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        [DisplayName("文章最后修改时间")]
        public DateTime? LastModifiedTime { get; set; }

        [DisplayName("阅读量")]
        public int ReaderNumber { get; set; }

        [DisplayName("点赞数")]
        public int Like { get; set; }

        [DisplayName("文章状态ID")]
        [Required]
        public int StateID { get; set; }

        [DisplayName("文章分类ID")]
        [Required]
        public int CategoryID { get; set; }

        [DisplayName("文章状态")]
        public virtual ArticleState State { get; set; }

        [DisplayName("文章分类")]
        public virtual Category Category { get; set; }

        [DisplayName("文章评论")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
