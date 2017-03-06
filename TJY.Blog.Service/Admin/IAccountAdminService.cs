using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJY.Blog.Common;
using TJY.Blog.Model;

namespace TJY.Blog.Service.Admin
{
    /// <summary>
    /// 后台-账户服务接口
    /// </summary>
    public interface IAccountAdminService:IDependency
    {
        /// <summary>
        /// 登录后台
        /// </summary>
        bool Login(string loginName, string password);

        /// <summary>
        /// 修改密码
        /// </summary>
        bool ModifyPwd(string oldPwd, string newPwd);

        /// <summary>
        /// 忘记密码(发送密码给指定邮箱)
        /// </summary>
        bool ForgetPwd();

        /// <summary>
        /// 编辑账户信息
        /// </summary>
        bool EditAccount(Account account);

        /// <summary>
        /// 获得账户信息(博客系统只有一个账号，因此在实现上采用获取所有并取第一个的方式)
        /// </summary>
        Account GetAccount();
    }
}
