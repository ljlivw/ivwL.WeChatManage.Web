using System;
using System.Collections.Generic;
using System.Text;

namespace ivwL.WeChat.Utilities.Cache
{
    public interface ICacheUtil
    {
        void Set(string key, string value);
        string Get(string key);
        T Get<T>(string key) where T : class;
        void Remove(string key);
        bool IsExist(string key);
        List<string> GetKeys();
    }
}
