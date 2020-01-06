using Autofac;
using Autofac.Builder;
using ivwL.WeChat.Dao;
using ivwL.WeChat.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ivwL.WeChat.Utilities.Autofac
{
    public class AutofacContainer
    {
        private readonly IContainer container;
        #region 使用单例模式对对象实例化
        private static AutofacContainer aufacContainer = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AutofacContainer GetInstance()
        {
            if (aufacContainer == null)
            {
                //使用原子操作方式实现单例模式，解决了多线程问题与双重判断加锁的代码多问题
                Interlocked.CompareExchange<AutofacContainer>(ref aufacContainer, new AutofacContainer(), null);
            }
            return aufacContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        private AutofacContainer() => container = BuildAutofacContainer();
        #endregion

        private IContainer BuildAutofacContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                RegisterTypes(builder);
                return builder.Build(ContainerBuildOptions.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.Register(a => new Sys_InfoDao(CacheData.ConnectionStrings.ivwL, CacheData.ConnectionStrings.ivwLDataBaseType)).As<ISys_InfoDao>();//注册系统信息
            builder.Register(a => new Sys_UserDao(CacheData.ConnectionStrings.ivwL, CacheData.ConnectionStrings.ivwLDataBaseType)).As<ISys_UserDao>();//注册系统用户
        }

        public T GetObject<T>() => container.Resolve<T>();

        public T GetObject<T>(string name) => container.ResolveNamed<T>(name);
    }
}
