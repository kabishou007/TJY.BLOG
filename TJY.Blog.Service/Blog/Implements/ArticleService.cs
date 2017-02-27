using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Blog.Implements
{
    internal class ArticleService:IArticleService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public Article GetArticleByID(int articleID)
        {
            return _unitOfWork.GetRepository<Article>().Get(articleID);
        }

        public List<Article> GetResentArticles(int articleNumber, int pageIndex, out int totalNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList<DateTime>(a => a.CreateTime, false, articleNumber, pageIndex, out totalNumber).ToList();
        }

        public List<Article> GetTopReadArticles(int articleNumber)
        {
            int totalCount;
            return _unitOfWork.GetRepository<Article>().GetPageList<int>(a => a.ReaderNumber, false, articleNumber, pageIndex, out totalCount).ToList();
        }

        public List<Article> GetArticlesByTitle(string articleTitle, int articleNumber, int pageIndex, out int totalNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.Title.Contains(articleTitle), articleNumber, pageIndex, out totalNumber).ToList();
        }

        public List<Article> GetArticlesByCategoryID(int categoryID, int articleNumber, int pageIndex, out int totalNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.CategoryID == categoryID, articleNumber, pageIndex, out totalNumber).ToList();
        }

        public bool AddLike(int articleID)
        {
            Article article=_unitOfWork.GetRepository<Article>().Get(articleID);
            article.Like += 1;
            _unitOfWork.GetRepository<Article>().Edit(article, new string[] { "Like" });
            return _unitOfWork.Commit();
        }

        public bool AddReadNumber(int articleID)
        {
            Article article = _unitOfWork.GetRepository<Article>().Get(articleID);
            article.ReaderNumber += 1;
            _unitOfWork.GetRepository<Article>().Edit(article, new string[] { "ReaderNumber" });
            return _unitOfWork.Commit();
        }

        #endregion


       
    }
}
