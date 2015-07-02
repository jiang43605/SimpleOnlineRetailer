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
    /// the SellInfo interface
    /// </summary>
    public class SellInfoSDK
    {
        /// <summary>
        /// ��ҳ������ڳ��۵���Ʒ��
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<SellInfo> GetSellInfoByPage(int pagesize, int pageindex)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/SellInfo/GetSellInfoByPage/{0}/{1}", pagesize, pageindex);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<List<SellInfo>>(str);
        }
        /// <summary>
        /// ����sellid������Ʒ
        /// </summary>
        /// <param name="sellid"></param>
        /// <returns></returns>
        public SellInfo GetSellInfoById(string sellid)
        {
            if (ApiV.IsNull(sellid)) return null;

            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/SellInfo/GetSellInfoById/{0}", sellid);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<SellInfo>(str);
        }
        /// <summary>
        /// �ϼ�һ����Ʒ
        /// </summary>
        /// <param name="pdid"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public ResponseMsg PutAway(string pdid, string describe)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/SellInfo/PutAway/{0}/{1}", pdid, describe);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ���������ϼܣ�����json����
        /// </summary>
        /// <returns></returns>
        public ResponseMsg BatchPutAway(List<SellInfo> sellInfos)
        {

            Cf_HttpWeb _httpweb = new Cf_HttpWeb
            {
                ContentType = "text/html",
                UserDate = JsonConvert.SerializeObject(sellInfos)
            };
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/SellInfo/BatchPutAway";
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ����sellid�¼���Ʒ
        /// </summary>
        /// <param name="sellid"></param>
        /// <returns></returns>
        public ResponseMsg OutAway(string sellid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/SellInfo/OutAway/{0}", sellid);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }
    }

}
