using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace APIService.Models
{
    public static class JsonHelp
    {
        /// <summary>
        /// 获得一个json提示信息
        /// </summary>
        /// <param name="statuscode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResponseMessage GetJsonContent(int statuscode, string msg)
        {
            string message = JsonConvert.SerializeObject(new JsonContent { StatusCode = statuscode, Message = msg });
            return new HttpResponseMessage { Content = new StringContent(message, Encoding.UTF8, "application/json") };
        }

    }

    /// <summary>
    /// 通用的Json消息体
    /// </summary>
    public class JsonContent
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