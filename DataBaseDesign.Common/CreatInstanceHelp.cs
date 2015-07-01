using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataBaseDesign.Common
{
    /// <summary>
    /// 创建实例帮助类
    /// </summary>
    public static class CreatInstanceHelp
    {
        /// <summary>
        /// 根据url创建指定的T对象，出现错误将返回null（包括程序集不存在等）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyurl"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T CreatInstanceByUrl<T>(string assemblyurl, string name) where T : class
        {
            T instance;
            try
            {
                Assembly assembly = Assembly.LoadFile(assemblyurl);
                instance = Activator.CreateInstance(assembly.GetType(name)) as T;
            }
            catch
            {

                return null;
            }
            return instance;
        }

        /// <summary>
        /// 根据配置文件创建实例，assemblykey表示程序集key的名称，classkey表示类key的名称（此value应该包括命名空间）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblykey"></param>
        /// <param name="classkey"></param>
        /// <returns></returns>
        public static T CreatInstanceByConfig<T>(string assemblykey, string classkey) where T : class
        {
            string assemblyurl = ConfigurationManager.AppSettings[assemblykey];
            string classurl = ConfigurationManager.AppSettings[classkey];
            if (assemblyurl == null || classurl == null) return null;
            return CreatInstanceByUrl<T>(assemblyurl, classurl);
        }
        /// <summary>
        /// 根据配置文件创建实例，assemblykey表示程序集key的名称（直接写程序集名称即可），classkey表示类key的名称（此value应该包括命名空间），
        /// 创建的实例需要都放置于网站根目录下的lib文件夹中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblykey"></param>
        /// <param name="classkey"></param>
        /// <returns></returns>
        public static T CreatInstanceByConfigOnlyUserAssemblyName<T>(string assemblykey, string classkey) where T : class
        {
            string assemblyurl = ConfigurationManager.AppSettings[assemblykey];
            string classurl = ConfigurationManager.AppSettings[classkey];
            if (assemblyurl == null || classurl == null) return null;
            assemblyurl = HttpContext.Current.Server.MapPath("~/lib/" + assemblyurl);
            return CreatInstanceByUrl<T>(assemblyurl, classurl);
        }
        /// <summary>
        /// 根据url创建指定的T对象（assemblyurl仅需输入程序集名称即可，因为默认到网站根目录下的lib文件夹中去寻找），
        /// 出现错误将返回null（包括程序集不存在等）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyurl"></param>
        /// <param name="classkey"></param>
        /// <returns></returns>
        public static T CreatInstanceByUrlOnlyUserAssemblyName<T>(string assemblyurl, string classkey) where T : class
        {
            assemblyurl = HttpContext.Current.Server.MapPath("~/lib/" + assemblyurl);
            return CreatInstanceByUrl<T>(assemblyurl, classkey);
        }
    }
}
