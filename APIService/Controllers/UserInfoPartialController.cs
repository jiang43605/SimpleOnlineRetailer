using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIService.Models;
using AutoMapper;
using DataBaseDesign.Cache;
using DataBaseDesign.Model;
using ServiceStack.Redis;

namespace APIService.Controllers
{
    public partial class UserInfoController
    {
        /// <summary>
        /// 注册UserInfo账户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("CreatAccount/{account}/{password}")]
        [Describe("买家注册", "用于创建一个账户，此账户用于买家，account（账户）和password（密码）为必填参数")]
        [HttpGet]
        public HttpResponseMessage CreatAccount(string account, string password)
        {
            if (!ApiVerification.VerificationNull(account, password))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            UserInfo userInfo = this._iUserInfoService.Where(o => o.Account == account).FirstOrDefault();
            if (userInfo != null) return JsonHelp.GetJsonContent(0, "此账户已经被注册");

            UserInfo newUserInfo = new UserInfo
            {
                UserId = Guid.NewGuid(),
                Account = account,
                Password = password,
                SubTime = DateTime.Now,
                RegisteTime = DateTime.Now
            };

            // 缓存
            this._RedisCache.Set(account, Mapper.Map<DataUserInfo>(newUserInfo));

            return this._iUserInfoService.CreatAccount(newUserInfo)
                ? JsonHelp.GetJsonContent(200, "已经成功创建")
                : JsonHelp.GetJsonContent(0, "创建失败");
        }

        /// <summary>
        /// 根据account获得用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("GetUserInfoByAccount/{account}")]
        [Describe("获取买家信息", "根据用户账号名，即通过account（账户）获取到这个用户的基本信息")]
        [HttpGet]
        public object GetUserInfoByAccount(string account)
        {
            if (!ApiVerification.VerificationNull(account))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            // 先查看缓存是否有
            DataUserInfo userinfocache = this._RedisCache.Get(account);

            if (userinfocache != null)
            {
                return userinfocache;
            }

            UserInfo userInfo = this._iUserInfoService.Where(o => o.Account == account).FirstOrDefault();
            if (userInfo == null)
            {
                return JsonHelp.GetJsonContent(0, "此账户不存在");
            }

            var datauserinfo = Mapper.Map<DataUserInfo>(userInfo);
            this._RedisCache.Set(account, datauserinfo);
            return datauserinfo;
        }

        /// <summary>
        /// 修改账户信息，请传递Post数据（Json）
        /// </summary>
        /// <returns></returns>
        [Route("UpdataAccount")]
        [Describe("修改买家信息", "修改账户的信息，请发出Post请求，数据格式应该为Json，否则将返回错误！")]
        [HttpPost]
        public HttpResponseMessage UpdataAccount()
        {
            UserInfo userInfo = PostHelp.GetPostInstance<UserInfo>();
            if (userInfo == null) return JsonHelp.GetJsonContent(0, "传入的json格式错误");

            var datauserinfo = this._iUserInfoService.Where(o => o.UserId == userInfo.UserId).FirstOrDefault();
            if (datauserinfo == null) return JsonHelp.GetJsonContent(0, "此帐号从未被注册过");

            datauserinfo.Age = userInfo.Age;
            datauserinfo.Name = userInfo.Name;
            datauserinfo.Phone = userInfo.Phone;
            datauserinfo.Sex = userInfo.Sex;
            datauserinfo.SubTime = DateTime.Now;

            // 缓存
            this._RedisCache.Set(datauserinfo.Account, Mapper.Map<DataUserInfo>(datauserinfo));

            return this._iUserInfoService.UpdataEntry(datauserinfo) ?
                 JsonHelp.GetJsonContent(200, "修改成功")
                 : JsonHelp.GetJsonContent(0, "修改失败");
        }

        /// <summary>
        /// 注销账户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("LogoutAccount/{account}")]
        [Describe("注销买家账户", "根据用户账号名，将某个账户从数据库中软删除")]
        [HttpGet]
        public HttpResponseMessage LogoutAccount(string account)
        {
            if (!ApiVerification.VerificationNull(account))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            UserInfo userInfo = this._iUserInfoService.Where(o => o.Account == account).FirstOrDefault();
            if (userInfo == null) return JsonHelp.GetJsonContent(0, "此账户本就不存在");

            if (userInfo.IsDelete) return JsonHelp.GetJsonContent(0, "此账户已经被注销了");
            userInfo.IsDelete = true;

            //缓存
            this._RedisCache.Set(userInfo.Account, Mapper.Map<DataUserInfo>(userInfo));

            return this._iUserInfoService.UpdataEntry(userInfo)
                ? JsonHelp.GetJsonContent(200, "注销成功")
                : JsonHelp.GetJsonContent(0, "注销失败");
        }
    }
}
