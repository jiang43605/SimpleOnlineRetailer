using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIService.Models;
using AutoMapper;
using DataBaseDesign.IService;
using DataBaseDesign.Model;

namespace APIService.Controllers
{
    public partial class ProviderController
    {
        private IUserInfoService _iUserInfoService { set; get; }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("RegisterAccount/{account}/{password}/{name}")]
        [Describe("供应商注册", "account（账户名），password（密码），name（名称）这些参数都是必不可少的")]
        [HttpGet]
        public HttpResponseMessage RegisterAccount(string account, string password, string name)
        {
            if (!ApiVerification.VerificationNull(account, password, name))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            Provider provider = this._iProviderService.Where(o => o.Account == account).FirstOrDefault();
            if (provider != null) return JsonHelp.GetJsonContent(0, "此账户已经被注册");

            UserInfo userinfo = this._iUserInfoService.Where(o => o.Account == account).FirstOrDefault();
            if (userinfo != null) return JsonHelp.GetJsonContent(0, "此账户已经被注册");

            Provider newProvider = new Provider
            {
                ProviderId = Guid.NewGuid(),
                Name = name,
                RegisterTime = DateTime.Now,
                Account = account,
                SubTime = DateTime.Now,
                Password = password
            };

            // 缓存
            this._RedisCache.Set(account, Mapper.Map<DataProvider>(newProvider));

            return this._iProviderService.CreatAccount(newProvider)
                ? JsonHelp.GetJsonContent(200, "已经成功注册")
                : JsonHelp.GetJsonContent(0, "注册失败");
        }

        /// <summary>
        /// 根据账户获取供应商信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("GetProvider/{account}")]
        [Describe("供应商注册", "传入account（帐户名）即可获得该供应商家信息")]
        public object GetProvider(string account)
        {
            if (!ApiVerification.VerificationNull(account))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            // 从缓存中取出数据
            DataProvider dataprovider = this._RedisCache.Get(account);
            if (dataprovider != null) return dataprovider;

            Provider provider = this._iProviderService.Where(o => o.Account == account).FirstOrDefault();
            if (provider == null) return JsonHelp.GetJsonContent(0, "此账户不存在");

            return Mapper.Map<DataProvider>(provider);
        }
    }
}
