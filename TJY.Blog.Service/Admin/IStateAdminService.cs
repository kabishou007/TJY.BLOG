using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-文章状态管理服务接口
    /// </summary>
    public interface IStateAdminService:IDependency
    {
        /// <summary>
        /// 增加文章状态
        /// </summary>
        bool AddState(ArticleState state);

        /// <summary>
        /// 编辑文章状态
        /// </summary>
        bool EditState(ArticleState state);

        /// <summary>
        /// 删除文章状态
        /// </summary>
        bool DeleteState(int stateID);

        /// <summary>
        /// 批量删除文章状态
        /// </summary>
        bool BulkDeleteState(List<int> stateIDs);

        /// <summary>
        /// 通过ID获取文章状态
        /// </summary>
        ArticleState GetStateByID(int id);

        /// <summary>
        /// 获取所有文章状态
        /// </summary>
        List<ArticleState> GetAllStates();
    }
}
