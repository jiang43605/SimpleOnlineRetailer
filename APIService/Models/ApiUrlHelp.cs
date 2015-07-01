using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace APIService.Models
{
    /// <summary>
    /// 生成api地址的帮助类
    /// </summary>
    internal static class ApiUrlHelp
    {
        /// <summary>
        /// 获得url地址集合
        /// </summary>
        /// <returns></returns>
        internal static ApiDescribeModel[] GetApiUrlList(params Type[] types)
        {
            List<ApiDescribeModel> list = new List<ApiDescribeModel>();
            foreach (var obj in types)
            {
                Type type = obj;
                string pre = type.GetCustomAttribute<RoutePrefixAttribute>().Prefix;

                IEnumerable<ApiDescribeModel> routeAttributes =
                    type.GetMethods()
                        .Select(o =>
                        {
                            var routmsg = o.GetCustomAttribute<RouteAttribute>();
                            if (routmsg == null) return null;
                            var describe = o.GetCustomAttribute<DescribeAttribute>();
                            return describe == null
                                ? new ApiDescribeModel
                                {
                                    ApiUrl = string.Format("/{0}/{1}", pre, routmsg.Template),
                                    DescribeItem = "暂时未提供描述信息",
                                    Head = "未知",
                                    Glyphicon = "glyphicon glyphicon-question-sign"
                                }
                                : new ApiDescribeModel
                                {
                                    ApiUrl = string.Format("/{0}/{1}", pre, routmsg.Template),
                                    DescribeItem = describe.DescribeItem,
                                    Head = describe.DescribeHead,
                                    Glyphicon = describe.Glyphicon
                                };
                        })
                        .TakeWhile(o => o != null);
                list.AddRange(routeAttributes);
                list.Add(null);
            }
            if (list.Last()==null) list.RemoveAt(list.Count-1);
            return list.ToArray();
        }
    }
}