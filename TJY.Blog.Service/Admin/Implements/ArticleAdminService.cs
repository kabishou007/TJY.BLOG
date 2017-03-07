using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class ArticleAdminService : IArticleAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public ArticleAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public bool SaveArticle(Article article)
        {
            int draftStateID=_unitOfWork.GetRepository<ArticleState>().Get(s => s.Name == "草稿").ID;
            if (article.StateID!=draftStateID)
            {
                article.StateID = draftStateID;
            }
            _unitOfWork.GetRepository<Article>().Add(article);
            return _unitOfWork.Commit();
        }

        public bool SaveAndPublishArticle(Article article)
        {
            int publishStateID = _unitOfWork.GetRepository<ArticleState>().Get(s => s.Name == "发布").ID;
            if (article.StateID != publishStateID)
            {
                article.StateID = publishStateID;
            }
            _unitOfWork.GetRepository<Article>().Add(article);
            ModifyArticleCount(article.CategoryID, true);
            return _unitOfWork.Commit();
        }

        public bool PublishArticle(int articleID)
        {
            int publishStateID = _unitOfWork.GetRepository<ArticleState>().Get(s => s.Name == "发布").ID;
            ChangeState(articleID, publishStateID);
            return _unitOfWork.Commit();
        }

        public bool EditArticle(Article article)
        {
            _unitOfWork.GetRepository<Article>().Edit(article);
            return _unitOfWork.Commit();
        }

        public bool DeleteArticle(int articleID)
        {
            int deleteStateID = _unitOfWork.GetRepository<ArticleState>().Get(s => s.Name == "删除").ID;
            ChangeState(articleID, deleteStateID);
            int categoryId = _unitOfWork.GetRepository<Article>().Get(articleID).CategoryID;
            ModifyArticleCount(categoryId, false);
            return _unitOfWork.Commit();
        }

        public bool BulkDeleteArticles(List<int> articleIDs)
        {
            int deleteStateID = _unitOfWork.GetRepository<ArticleState>().Get(s => s.Name == "删除").ID;
            foreach (int articleID in articleIDs)
            {
                ChangeState(articleID, deleteStateID);
                int categoryId = _unitOfWork.GetRepository<Article>().Get(articleID).CategoryID;
                ModifyArticleCount(categoryId, false);
            }
            return _unitOfWork.Commit();
        }

        public Article GetArticleByID(int articleID)
        {
            return _unitOfWork.GetRepository<Article>().Get(articleID);
        }

        public List<Article> GetResentArticles(int pageSize, int pageIndex, out int totalCount, bool isAsc = false)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList<DateTime>( a => a.CreateTime, isAsc, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Article> GetArticlesByTitle(string title, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.Title.Contains(title), pageSize, pageIndex, out totalCount).ToList();
        }

        public List<Article> GetArticlesByCategoryID(int categoryID, int pageSize, int pageIndex, out int totalCount)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.CategoryID == categoryID, pageSize, pageIndex, out totalCount).ToList();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 改变文章状态
        ///</summary>
        private void ChangeState(int articleID, int stateID)
        {
            Article article = _unitOfWork.GetRepository<Article>().Get(articleID);
            article.StateID = stateID;
            _unitOfWork.GetRepository<Article>().Edit(article, new string[] { "StateID" });
        } 

        /// <summary>
        /// 改变某分类文章数量
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        /// <param name="isIncrease">是否增加数量</param>
        private void ModifyArticleCount(int categoryId,bool isIncrease)
        {
            Category category=_unitOfWork.GetRepository<Category>().Get(categoryId);
            category.ArticleCount = isIncrease ? category.ArticleCount + 1 : category.ArticleCount - 1;
            _unitOfWork.GetRepository<Category>().Edit(category, new string[] { "ArticleCount" });
        }
        #endregion
    }
}
