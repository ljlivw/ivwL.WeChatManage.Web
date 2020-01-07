using ivwL.WeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Utilities
{
    public class CacheData
    {
        #region 私有类
        private static Cache.ICacheUtil _cache;
        #endregion

        public static ConnectionStrings ConnectionStrings { get; set; }
        public static AppSettings AppSettings { get; set; }
        public static Cache.ICacheUtil Cahce { get { if (_cache == null) { _cache = new Cache.CacheFactory().Cache(); } return _cache; } }
    }

    public sealed class ConnectionStrings
    {
        public string ivwL { get; set; }
        public string ivwLDataBaseType { get; set; }
    }
    public sealed class AppSettings
    {
        /// <summary>
        /// 缓存方式【session，cookie】
        /// </summary>
        public string LoginProvider { get; set; }
        /// <summary>
        /// 缓存过程有效时间
        /// </summary>
        public int CacheEffectiveTime { get; set; }
    }
}
