using System;
using System.Collections.Generic;
using System.Text;

namespace ivwL.WeChat.Utilities.Cache
{
    public class CacheFactory
    {
        public ICacheUtil Cache()
        {
            switch (CacheData.AppSettings.LoginProvider.ToLower())
            {
                case "cookie": return new CookieUtil();
                case "session": return new SessionUtil();
                default: return new CookieUtil();
            }
        }
    }
}
