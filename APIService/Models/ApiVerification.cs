using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace APIService.Models
{
    /// <summary>
    /// 一些通用于api的验证
    /// </summary>
    internal static class ApiVerification
    {
        /// <summary>
        /// 所有参数都不能为空，都不为空则返回true，否则返回false
        /// </summary>
        /// <param name="pStrings"></param>
        /// <returns></returns>
        internal static bool VerificationNull(params string[] pStrings)
        {
            return pStrings.All(o => !string.IsNullOrEmpty(o));
        }
    }
}