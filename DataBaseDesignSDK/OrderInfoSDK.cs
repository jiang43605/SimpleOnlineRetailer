using DataBaseDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chengf;
using Newtonsoft.Json;

namespace DataBaseDesignSDK
{
    /// <summary>
    /// the OrderInfo interface
    /// </summary>
    public class OrderInfoSDK
    {
        /// <summary>
        /// 创建一个订单
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sellid"></param>
        /// <returns></returns>
        public ResponseMsg AddOrderInfo(string userid, string sellid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/OrderInfo/AddOrderInfo/{0}/{1}", userid, sellid);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ResponseMsg DeleteOrderInfo(string orderId)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/OrderInfo/DeleteOrderInfo/" + orderId;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 查找单个订单的信息
        /// </summary>
        /// <param name="orederid"></param>
        /// <returns></returns>
        public OrderInfo GetOrderInfoById(string orederid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/OrderInfo/GetOrderInfoById/orederid" + orederid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<OrderInfo>(str);
        }

        /// <summary>
        /// 根据用户id查询订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<OrderInfo> GetOrderInfoByUserId(string userid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/OrderInfo/GetOrderInfo/" + userid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<List<OrderInfo>>(str);
        }
    }

}
