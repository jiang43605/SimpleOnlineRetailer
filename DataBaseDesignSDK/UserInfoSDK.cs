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

    public class UserInfoSDK
    {

        public ResponseMsg CreatAccount(string account, string password)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";;
            string url = string.Format("http://localhost:32839/api/restful/UserInfo/CreatAccount/{0}/{1}", account, password);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 根据account获得用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        public UserInfo GetUserInfoByAccount(string account)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";;
            string url = string.Format("http://localhost:32839/api/restful/UserInfo/GetUserInfoByAccount/{0}", account);
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            if (str.Contains("\"StatusCode\":0")) return null;
            return JsonConvert.DeserializeObject<UserInfo>(str);
        }

        /// <summary>
        /// 修改账户信息，请传递Post数据（Json）
        /// </summary>
        /// <returns></returns>

        public ResponseMsg UpdataAccount(int? age, string name, string phone, bool? sex)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";;
            UserInfo userInfo = new UserInfo
            {
                Age = age,
                Name = name,
                Phone = phone,
                Sex = sex
            };
            _httpweb.ContentType = "text/html";
            _httpweb.UserDate = JsonConvert.SerializeObject(userInfo);
            string url = "http://localhost:32839/api/restful/UserInfo/UpdataAccount";
            string str = _httpweb.PostOrGet(url, HttpMethod.POST).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

        /// <summary>
        /// 注销账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        public ResponseMsg LogoutAccount(string account)
        {
            Cf_HttpWeb _httpweb = new Cf_HttpWeb();
            _httpweb.EncodingSet = "utf-8";; 
            string url = "http://localhost:32839/api/restful/UserInfo/LogoutAccount/" + account;
            string str = _httpweb.PostOrGet(url, HttpMethod.GET).HtmlValue;
            return JsonConvert.DeserializeObject<ResponseMsg>(str);
        }

    }

}
