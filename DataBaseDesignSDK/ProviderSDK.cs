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
    /// the Provider interface
    /// </summary>
    public class ProviderSDK
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public ResponseMsg RegisterAccount(string account, string password, string name)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/Provider/RegisterAccount/{0}/{1}/{2}", account, password, name);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 根据账户获取供应商信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Provider GetProvider(string account)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";
            string url = string.Format("http://localhost:32839/api/restful/Provider/GetProvider/{0}", account);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<Provider>(str);
        }
    }

}
