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
        
        public List<Article> GetFirstPageArticles(int articleNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList<DateTime>(a => a.CreateTime, false, articleNumber, 1, out articleNumber).ToList();
        }

        public List<Article> GetTopReadArticles(int articleNumber)
        {
             return _unitOfWork.GetRepository<Article>().GetPageList<int>(a => a.ReaderNumber, false, articleNumber, 1, out articleNumber).ToList();
        }

        public List<Article> GetArticlesByTitle(string articleTitle, int articleNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.Title.Contains(articleTitle), articleNumber, 1, out articleNumber).ToList();
        }

       public List<Article> GetArticlesByCategoryID(int categoryID,int articleNumber)
        {
            return _unitOfWork.GetRepository<Article>().GetPageList(a => a.CategoryID==categoryID, articleNumber, 1, out articleNumber).ToList();
        }
        #endregion
    }
}
