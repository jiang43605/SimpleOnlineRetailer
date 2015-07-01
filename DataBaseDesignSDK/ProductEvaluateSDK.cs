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
    /// the ProductEvaluate interface
    /// </summary>
    public class ProductEvaluateSDK
    {
        /// <summary>
        /// 添加一个商品评论，使用Post(json)
        /// </summary>
        /// <returns></returns>
        public ResponseMsg AddProductEvaluate(Guid pdid, string item, Guid userid)
        {
            ProductEvaluate productEvaluate = new ProductEvaluate
            {
                PdId = pdid,
                UserId = userid,
                EvaTime = DateTime.Now,
                SubTime = DateTime.Now
            };
            Cf_HttpWeb _httpweb = new Cf_HttpWeb
            {
                ContentType = "text/html",
                UserDate = JsonConvert.SerializeObject(productEvaluate)
            };
            _httpweb.EncodingSet = "utf-8";
            const string url = "http://localhost:32839/api/restful/ProductEvaluate/AddProductEvaluate";
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 根据商品Id返回该商品的所有评论
        /// </summary>
        /// <returns></returns>
        public List<ProductEvaluate> GetProductEvaluateByPdId(string pdid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/ProductEvaluate/GetProductEvaluateByPdId/{0}", pdid);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<List<ProductEvaluate>>(str);
        }
    }

}
