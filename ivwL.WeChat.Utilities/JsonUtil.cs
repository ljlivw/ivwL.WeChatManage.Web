using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ivwL.WeChat.Utilities
{
    public static class JsonUtil
    {
        /// <summary>
        /// ToJson（去NULL值）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        /// <summary>
        /// ToModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public static T ToModel<T>(this string sJson) where T : class => JsonConvert.DeserializeObject<T>(sJson);
    }
}
