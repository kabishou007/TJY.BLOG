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
        public bool CommentArticleOrReply(Comment comment)
        {
            _unitOfWork.GetRepository<Comment>().Add(comment);
            return _unitOfWork.Commit();
        }
        #endregion
    }
}
