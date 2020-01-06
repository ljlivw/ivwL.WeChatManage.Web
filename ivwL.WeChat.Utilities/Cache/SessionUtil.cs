using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ivwL.WeChat.Utilities.Cache
{
    public class SessionUtil : ICacheUtil
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Set(string key, string value) => MyHttpContext.Current.Session.SetString(key, value);
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key) => MyHttpContext.Current.Session.GetString(key);
        /// <summary>
        /// 获取Session
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
        /// 删除Session
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key) => MyHttpContext.Current.Session.Remove(key);
        /// <summary>
        /// 判断Session是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key) => GetKeys().Any(a => a == key);
        /// <summary>
        /// 获取所有Session键
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys() => MyHttpContext.Current.Session.Keys.ToList();
    }
}
