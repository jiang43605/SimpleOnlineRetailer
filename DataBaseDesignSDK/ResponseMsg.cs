using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesignSDK
{
    /// <summary>
    /// 返回状态
    /// </summary>
    public class ResponseMsg
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { set; get; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { set; get; }
    }
}
