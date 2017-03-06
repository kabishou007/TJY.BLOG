using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class CommentAdminService : ICommentAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public CommentAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public bool DeleteComment(int commentID)
        {
            if (DeleteChildComments(commentID) == false)
            {
                _unitOfWork.GetRepository<Comment>().Delete(commentID);
            }
            return _unitOfWork.Commit();
        }

        public bool BulkDeleteComments(List<int> commentIDs)
        {
            foreach (int commentID in commentIDs)
            {
                if (DeleteChildComments(commentID) == false)
                {
                    _unitOfWork.GetRepository<Comment>().Delete(commentID);
                }
            }
            return _unitOfWork.Commit();
        }

        public Comment GetCommentByID(int commentID)
        {
            return _unitOfWork.GetRepository<Comment>().Get(commentID);
        }

        public List<Comment> GetCommentsByArticleTitle(string articleTitle, int pageSize, int pageIndex, out int totalCount, bool isAsc = true)
        {
            return _unitOfWork.GetRepository<Comment>().GetPageList<DateTime>(c => c.Article.Title == articleTitle, c => c.CreateTime, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Comment> GetCommentsByEmail(string email, int pageSize, int pageIndex, out int totalCount, bool isAsc = true)
        {
            return _unitOfWork.GetRepository<Comment>().GetPageList<DateTime>(c => c.Email == email, c => c.CreateTime, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Comment> GetCommentsByContent(string content, int pageSize, int pageIndex, out int totalCount, bool isAsc = true)
        {
            return _unitOfWork.GetRepository<Comment>().GetPageList<DateTime>(c => c.Content.Contains(content), c => c.CreateTime, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Comment> GetResentComments(int pageSize, int pageIndex, out int totalCount, bool isAsc = false)
        {
            return _unitOfWork.GetRepository<Comment>().GetPageList<DateTime>(c => c.CreateTime, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }


        #endregion


        #region 私有方法
        /// <summary>
        /// 删除子评论
        /// 递归：当某评论无子评论可删时，删除其本身
        /// </summary>
        private bool DeleteChildComments(int parentCommentID)
        {
            IQueryable<Comment> childComments = _unitOfWork.GetRepository<Comment>().GetList(c => c.ParentComment.ID == parentCommentID);
            if (childComments.Count() > 0)
            {
                List<Comment> list = childComments.ToList();
                foreach (Comment childComment in list)
                {
                    if (DeleteChildComments(childComment.ID) == false)
                    {
                        _unitOfWork.GetRepository<Comment>().Delete(childComment.ID);
                    }
                }
            }
            return false;
        } 
        #endregion
    }
}
