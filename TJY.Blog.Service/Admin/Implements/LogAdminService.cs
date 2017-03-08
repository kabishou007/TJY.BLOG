using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class LogAdminService:ILogAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public LogAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public List<OperationLog> GetLogsByDate(string date, int pageSize, int pageIndex, out int totalCount)
        {
           return _unitOfWork.GetRepository<OperationLog>().GetPageList(l => l.LogTime.ToString() == date, pageSize, pageIndex, out totalCount).ToList();
        }

        public List<OperationLog> GetResentLogs(int pageSize, int pageIndex, out int totalCount, bool isAsc = false)
        {
            return _unitOfWork.GetRepository<OperationLog>().GetPageList<string>(l=>l.LogTime,isAsc,pageSize,pageIndex,out totalCount).ToList(); ;
        } 
        #endregion
    }
}
