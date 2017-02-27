using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using TJY.Blog.Model;

namespace TJY.Blog.Data.ModelMap
{
    internal class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            //Comment:一对多自反关系
            this.HasOptional(c => c.ParentComment)
                .WithMany(c => c.ChildComments)
                .HasForeignKey(c => c.ParentID);
            //Comment-Article:一对多关系
            this.HasRequired(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleID);
        }
    }
}
