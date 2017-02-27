using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class StateAdminService:IStateAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public StateAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public bool AddState(ArticleState state)
        {
            _unitOfWork.GetRepository<ArticleState>().Add(state);
            return _unitOfWork.Commit();
        }

        public bool EditState(ArticleState state)
        {
            _unitOfWork.GetRepository<ArticleState>().Edit(state);
            return _unitOfWork.Commit();
        }

        public bool DeleteState(int stateID)
        {
            _unitOfWork.GetRepository<ArticleState>().Delete(stateID);
            return _unitOfWork.Commit();
        }

        public bool BulkDeleteState(List<int> stateIDs)
        {
            foreach (int stateID in stateIDs)
            {
                _unitOfWork.GetRepository<ArticleState>().Delete(stateID);
            }
            return _unitOfWork.Commit();
        }

        public ArticleState GetStateByID(int id)
        {
            return _unitOfWork.GetRepository<ArticleState>().Get(id);
        }

        public List<ArticleState> GetAllStates()
        {
            return _unitOfWork.GetRepository<ArticleState>().GetList().ToList();
        } 
        #endregion
    }
}
