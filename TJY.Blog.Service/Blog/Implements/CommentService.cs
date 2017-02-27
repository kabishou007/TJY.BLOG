using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog.Implements
{
    internal class CommentService:ICommentService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public bool AddComment(Comment comment)
        {
            _unitOfWork.GetRepository<Comment>().Add(comment);
            return _unitOfWork.Commit();
        }

        public List<Comment> GetCommentsByArticleID(int articleID, int commentNumber, int pageIndex, out int totalNumber)
        {
            List<Comment> comments = _unitOfWork.GetRepository<Comment>().GetPageList(c => c.ArticleID == articleID && c.IsArticleComment == true, commentNumber, pageIndex, out totalNumber).ToList();
            if (comments.Count>0)
            {
                foreach (Comment comment in comments)
                {
                    comment.ChildComments = GetChildComments(comment.ID);
                }
            }
            return comments;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 递归获取所有子评论
        /// </summary>
        private List<Comment> GetChildComments(int parentCommentID)
        {
            List<Comment> comments = _unitOfWork.GetRepository<Comment>().GetList(c => c.ParentID == parentCommentID).ToList();
            if (comments.Count > 0)
            {
                foreach (Comment comment in comments)
                {
                    comment.ChildComments = GetChildComments(comment.ID);
                }
            }
            return comments;
        } 
        #endregion
    }
}
