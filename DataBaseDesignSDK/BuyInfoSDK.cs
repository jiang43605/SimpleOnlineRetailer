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
    /// the BuyInfo interface
    /// </summary>
    public class BuyInfoSDK
    {
        /// <summary>
        /// �û�����һ����Ʒ������Post����
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ResponseMsg ReleaseBuyInfo(Guid userid, string Describe, DateTime DurationTime, string RequireProduceName)
        {
            BuyInfo newBuyInfo = new BuyInfo
            {
                Describe = Describe,
                DurationTime = DurationTime,
                RequireProduceName = RequireProduceName,
            };
            Cf_HttpWeb _httpweb = new Cf_HttpWeb
            {
                ContentType = "text/html",
                UserDate = JsonConvert.SerializeObject(newBuyInfo)
            };
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/BuyInfo/ReleaseBuyInfo/" + userid.ToString();
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="buyInfoid"></param>
        /// <returns></returns>
        public ResponseMsg DeleteBuyInfo(string buyInfoid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/BuyInfo/DeleteBuyInfo/buyInfoid" + buyInfoid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <returns></returns>
        public ResponseMsg UpdataBuyInfo(string buyid, string name, string describe, string durationtime)
        {

            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/BuyInfo/UpdataBuyInfo/{0}/{1}/{2}/{3}", buyid, name, describe, durationtime);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// ͨ������buyid���������ҳ���buyinfo��������Ϣ
        /// </summary>
        /// <param name="buyid"></param>
        /// <returns></returns>
        public BuyInfo GetBuyInfoById(string buyid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/BuyInfo/GetBuyInfoById/" + buyid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<BuyInfo>(str);
        }

        /// <summary>
        /// �����û�id��ѯ����
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<UserInfo> GetBuyInfoByUserId(string userid)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = "http://localhost:32839/api/restful/BuyInfo/GetBuyInfoByUserId/" + userid;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<List<UserInfo>>(str);
        }
    }

}
