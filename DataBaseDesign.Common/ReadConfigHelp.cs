using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.Common
{
    /// <summary>
    /// 读取配置文件帮助类
    /// </summary>
    public static class ReadConfigHelp
    {
        /// <summary>
        /// 根据key获得AppSettings的value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static List<string> GetAppSettingsVualeUseSplit(string key, char c)
        {
            string value = ConfigurationManager.AppSettings[key];
            return value.Split(new[] {c}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
