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
        public static ConnectionStrings ConnectionStrings { get; set; }
        public static AppSettings AppSettings { get; set; }
    }

    public sealed class ConnectionStrings
    {
        public string ivwL { get; set; }
        public string ivwLDataBaseType { get; set; }
    }
    public sealed class AppSettings
    {
        public string LoginProvider { get; set; }
        /// <summary>
        /// 缓存过程有效时间
        /// </summary>
        public int CacheEffectiveTime { get; set; }
    }
}
