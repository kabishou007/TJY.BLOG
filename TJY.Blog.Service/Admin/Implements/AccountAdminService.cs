using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Data;
using TJY.Blog.Model;
using TJY.Blog.Common;

namespace TJY.Blog.Service.Admin.Implements
{
    internal class AccountAdminService:IAccountAdminService
    {
        #region 构造注入
        private IUnitOfWork _unitOfWork;
        public AccountAdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region 实现接口
        public bool Login(string loginName, string password)
        {
            string aesPwd=new AESCrypt().Encrypt(password);
            Account account = _unitOfWork.GetRepository<Account>().Get(a => a.LoginName == loginName && a.Password == aesPwd);
            return account != null ? true : false;
        }

        public bool EditAccount(Account account)
        {
            _unitOfWork.GetRepository<Account>().Edit(account);
            return _unitOfWork.Commit();
        }

        public bool ModifyPwd(string oldPwd, string newPwd)
        {
            Account account=_unitOfWork.GetRepository<Account>().GetList().FirstOrDefault();
            if (account.Password==new AESCrypt().Encrypt(oldPwd))
            {
                account.Password = new AESCrypt().Encrypt(newPwd);
                return true;
            }
            return false;
        }


        public bool ForgetPwd()
        {
            //TODO:使用邮件服务，将密码发送至账户指定邮箱
            return true;
        }


        public Account GetAccount()
        {
            return _unitOfWork.GetRepository<Account>().GetList().FirstOrDefault();
        } 

        #endregion
    }
}
