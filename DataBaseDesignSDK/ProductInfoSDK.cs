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
    /// the ProductInfo interface
    /// </summary>
    public class ProductInfoSDK
    {
        /// <summary>
        /// ���һ����Ʒ���ݹ�Ӧ��ID��ʹ��Post(json)
        /// </summary>
        /// <param name="providerid"></param>
        /// <param name="PdName"></param>
        /// <param name="ProductDescribe"></param>
        /// <returns></returns>
        public ResponseMsg AddProduct(Guid providerid, string PdName, string ProductDescribe,float price,int num)
        {
            ProductInfo productInfo = new ProductInfo
            {
                PdNum = num,
                PdPrice = price,
                PdName = PdName,
                ProductDescribe = ProductDescribe
            };
            Cf_HttpWeb _httpweb = new Cf_HttpWeb
            {
                ContentType = "text/html",
                UserDate = JsonConvert.SerializeObject(productInfo)
            };
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/ProductInfo/AddProduct/{0}", providerid.ToString());
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ResponseMsg DeleteProduct(string productid)
        {

            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = " http://localhost:32839/api/restful/ProductInfo/DeleteProduct/" + productid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ����json�����޸�
        /// </summary>
        /// <returns></returns>
        public ResponseMsg UpdataProduct(Guid pdid, string pdName, double pdPrice, string productDescribe, int pdNum)
        {
            ProductInfo productInfo = new ProductInfo
            {
                PdId = pdid,
                PdName = pdName,
                PdPrice = pdPrice,
                ProductDescribe = productDescribe,
                PdNum = pdNum
            };
            Cf_HttpWeb _httpweb = new Cf_HttpWeb
            {
                ContentType = "text/html",
                UserDate = JsonConvert.SerializeObject(productInfo)
            };
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/ProductInfo/UpdataProduct";
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ����id��ѯ
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ProductInfo GetProduct(string productid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/ProductInfo/GetProduct/{0}", productid);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<ProductInfo>(str);
        }

        public List<ProductInfo> GetProducByProviderId(string account)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/ProductInfo/GetProducByProviderId/" + account;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<List<ProductInfo>>(str);
        }
    }

}
