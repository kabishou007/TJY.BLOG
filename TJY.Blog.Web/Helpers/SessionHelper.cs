using System.Web;

namespace TJY.Blog.Web.Helpers
{
    public class SessionHelper
    {
        /// <summary>
        /// 获取session
        /// </summary>
        /// <param name="sessionName">session名</param>
        /// <returns></returns>
        public static object GetSession(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="sessionName">session名</param>
        /// <param name="sessionValue">要设置的session值</param>
        /// <param name="expireTime">超时分钟(默认20分钟)</param>
        public static void SetSession(string sessionName, object sessionValue, int expireTime=20)
        {
            HttpContext.Current.Session.Remove(sessionName);
            HttpContext.Current.Session.Add(sessionName, sessionValue);
            HttpContext.Current.Session.Timeout = expireTime;
        }

        /// <summary>
        /// 删除session
        /// </summary>
        /// <param name="sessionName">session名</param>
        public static void RemoveSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        /// <summary>
        /// 删除所有session
        /// </summary>
        public static void RemoveAllSession(string sessionName)
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}
