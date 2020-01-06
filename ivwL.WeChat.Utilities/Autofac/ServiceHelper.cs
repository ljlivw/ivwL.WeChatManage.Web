using ivwL.WeChat.IDao;
using ivwL.WeChat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Utilities
{
    public class ServiceHelper
    {
        /// <summary>
        /// 系统信息服务
        /// </summary>
        public static Sys_InfoService Sys_InfoService { get; set; }
        /// <summary>
        /// 系统用户服务
        /// </summary>
        public static Sys_UserService Sys_UserService { get; set; }
        static ServiceHelper() => SetService();

        #region 设置Service值
        public static void SetService()
        {
            Sys_InfoService = new Sys_InfoService(Autofac.AutofacContainer.GetInstance().GetObject<ISys_InfoDao>());
            Sys_UserService = new Sys_UserService(Autofac.AutofacContainer.GetInstance().GetObject<ISys_UserDao>());

        }
        #endregion
    }
}
