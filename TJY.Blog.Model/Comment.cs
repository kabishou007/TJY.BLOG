using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJY.Blog.Model
{
    public class Comment
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("昵称")]
        [Required]
        [StringLength(10)]
        public string NickName { get; set; }

        [DisplayName("邮箱")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$")]
        public string Email { get; set; }

        [DisplayName("评论内容")]
        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        [DisplayName("评论时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        [DisplayName("文章的直接评论")]
        public bool IsArticleComment { get; set; }

        [DisplayName("评论文章ID")]
        public int ArticleID { get; set; }

        [DisplayName("父评论ID")]
        public int? ParentID { get; set; }

        [DisplayName("评论文章")]
        public virtual Article Article { get; set; }

        [DisplayName("父评论")]
        public virtual Comment ParentComment { get; set; }

        [DisplayName("子评论")]
        public virtual ICollection<Comment> ChildComments { get; set; }
    }
}
