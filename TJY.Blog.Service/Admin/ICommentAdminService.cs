using System.Collections.Generic;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-评论管理服务接口
    /// </summary>
    public interface ICommentAdminService : IDependency
    {
        /// <summary>
        /// 根据ID删除评论
        /// </summary>
        bool DeleteComment(int commentID);

        /// <summary>
        /// 根据Id集合批量删除评论
        /// </summary>
        bool BulkDeleteComments(List<int> commentIDs);

        /// <summary>
        /// 通过ID查询评论
        /// </summary>
        Comment GetCommentByID(int commentID);

        /// <summary>
        /// 通过文章标题查询评论列表（分页，按日期排序）
        /// </summary>
        /// <param name="articleTitle">文章标题</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认true)</param>
        List<Comment> GetCommentsByArticleTitle(string articleTitle, int pageSize, int pageIndex, out int totalCount, bool isAsc = true);

        /// <summary>
        /// 通过评论ID查询子评论（分页，按日期排列）
        /// </summary>
        /// <param name="parentCommentID">父评论ID</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认true)</param>
        //List<Comment> GetChildComments(int parentCommentID, int pageSize, int pageIndex, out int totalCount, bool isAsc = true);

        /// <summary>
        /// 通过email查询评论列表（分页，按日期排列）
        /// </summary>
        /// <param name="email">评论者昵称</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认true)</param>
        List<Comment> GetCommentsByEmail(string email, int pageSize, int pageIndex, out int totalCount, bool isAsc = true);

        /// <summary>
        /// 获取最新评论列表
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="isAsc">是否升序排列(默认false)</param>
        List<Comment> GetResentComments(int pageSize, int pageIndex, out int totalCount, bool isAsc = false);
    }
}
