using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DataBaseDesign.Model;
using Newtonsoft.Json;

namespace APIService.Models
{
    /// <summary>
    /// Post数据帮助类，抛出异常时将返回null
    /// </summary>
    internal static class PostHelp
    {
        internal static T GetPostInstance<T>() where T : class
        {
            string postdata;
            Stream stream = HttpContext.Current.Request.InputStream;
            using (StreamReader sr = new StreamReader(stream, HttpContext.Current.Request.ContentEncoding))
            {
                postdata = sr.ReadToEnd();
            }

            try
            {
                // 如果postdata为一个空的json，返回的也不会返回null，所以只有格式转换错误等才抛异常
                T sellInfos = JsonConvert.DeserializeObject<T>(postdata);
                return sellInfos;
            }
            catch
            {
                return null;
            }

            // stream等待系统自己关闭
        }
    }
}