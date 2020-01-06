using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ivwL.WeChat.Utilities.Cache
{
    public class CookieUtil : ICacheUtil
    {
        /// <summary>
        /// 设置Cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="Expires">过期时间【以分钟为单位】</param>
        public void Set(string key, string value) => MyHttpContext.Current.Response.Cookies.Append(key, value, new CookieOptions() { Expires = DateTime.Now.AddMinutes(CacheData.AppSettings.CacheEffectiveTime) });
        /// <summary>
        /// 获取Cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key)
        {
            MyHttpContext.Current.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }
        /// <summary>
        /// 获取Cookies
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            string s = Get(key);
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            return s.ToModel<T>();
        }
        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key) => MyHttpContext.Current.Response.Cookies.Delete(key);
        /// <summary>
        /// 判断Cookies是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool IsExist(string key) => MyHttpContext.Current.Request.Cookies.ContainsKey(key);
        /// <summary>
        /// 获取所有Cookies键
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys() => MyHttpContext.Current.Request.Cookies.Keys.ToList();
    }
}
