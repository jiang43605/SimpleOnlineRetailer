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
    public partial class BuyInfoController
    {
        private IUserInfoService _iUserInfoService { set; get; }
        /// <summary>
        /// 用户发布一个商品，请用Post数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [Route("ReleaseBuyInfo/{userid}")]
        [Describe("求购发布（POST）", "地址中应带useid参数，请使用Post请求，并传Describe（描述）、DurationTime（截至时间）、RequireProduceName（求购商品名）三个必须KEY")]
        [HttpPost]
        public HttpResponseMessage ReleaseBuyInfo(string userid)
        {
            var userinfo = this._iUserInfoService.Where(o => o.UserId.ToString() == userid).FirstOrDefault();
            if (userinfo == null) return JsonHelp.GetJsonContent(0, "无此用户");

            var buyinfo = PostHelp.GetPostInstance<BuyInfo>();
            if (!ApiVerification.VerificationNull(buyinfo.Describe, buyinfo.RequireProduceName))
                return JsonHelp.GetJsonContent(0, "必要的商品参数不能为空");

            BuyInfo newBuyInfo = new BuyInfo
            {
                BuyId = Guid.NewGuid(),
                Describe = buyinfo.Describe,
                DurationTime = buyinfo.DurationTime,
                RequireProduceName = buyinfo.RequireProduceName,
                SubTime = DateTime.Now,
                UserId = Guid.Parse(userid)
            };

            // 缓存
            this._RedisCache.Set(buyinfo.BuyId.ToString(), Mapper.Map<DataBuyInfo>(buyinfo));

            return this._iBuyInfoService.Add(newBuyInfo)
                ? JsonHelp.GetJsonContent(200, "添加成功")
                : JsonHelp.GetJsonContent(0, "添加失败");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="buyInfoid"></param>
        /// <returns></returns>
        [Route("DeleteBuyInfo/{buyInfoid}")]
        [Describe("求购发布", "根据buyInfoid（商品的id）硬删除，不会保留")]
        [HttpGet]
        public HttpResponseMessage DeleteBuyInfo(string buyInfoid)
        {
            var buyinfo = this._iBuyInfoService.Where(o => o.BuyId.ToString() == buyInfoid).FirstOrDefault();
            if (buyinfo == null) return JsonHelp.GetJsonContent(0, "没有检测到此发布信息");

            // 更新缓存
            this._RedisCache.Remove(buyInfoid);

            return this._iBuyInfoService.UpdataEntry(buyinfo)
                ? JsonHelp.GetJsonContent(200, "删除成功")
                : JsonHelp.GetJsonContent(0, "删除失败");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [Route("UpdataBuyInfo/{buyid}/{name}/{describe}/{durationtime}")]
        [Describe("求购发布", "根据buyInfoid（商品的id）查找，必须的参数为name、describe、durationtime，即这三个为可修改的数据")]
        [HttpGet]
        public HttpResponseMessage UpdataBuyInfo(string buyid, string name, string describe, string durationtime)
        {
            if (!ApiVerification.VerificationNull(buyid, name, describe, durationtime))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            DateTime datetime;
            bool isdatetime = DateTime.TryParse(durationtime, out datetime);
            if (!isdatetime) return JsonHelp.GetJsonContent(0, "日期的格式不正确");

            var databuyinfo = this._iBuyInfoService.Where(o => o.BuyId.ToString() == buyid).FirstOrDefault();
            if (databuyinfo == null) return JsonHelp.GetJsonContent(0, "发布的信息不存在");

            databuyinfo.SubTime = DateTime.Now;
            databuyinfo.RequireProduceName = name;
            databuyinfo.Describe = describe;
            databuyinfo.DurationTime = datetime;

            // 更新缓存
            this._RedisCache.Set(databuyinfo.BuyId.ToString(), Mapper.Map<DataBuyInfo>(databuyinfo));

            return this._iBuyInfoService.UpdataEntry(databuyinfo)
                ? JsonHelp.GetJsonContent(200, "修改成功")
                : JsonHelp.GetJsonContent(0, "修改失败");
        }

        /// <summary>
        /// 通过传递buyid参数，查找出该buyinfo的所有信息
        /// </summary>
        /// <param name="buyid"></param>
        /// <returns></returns>
        [Route("GetBuyInfoById/{buyid}")]
        [Describe("求购发布", "通过传递buyid参数，查找出该buyinfo的所有信息")]
        [HttpGet]
        public object GetBuyInfoById(string buyid)
        {
            if (!ApiVerification.VerificationNull(buyid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            // 缓存中取数据
            DataBuyInfo databuyinfo = this._RedisCache.Get(buyid);
            if (databuyinfo != null) return databuyinfo;

            BuyInfo buyinfo = this._iBuyInfoService.Where(o => o.BuyId.ToString() == buyid).FirstOrDefault();
            if (buyinfo == null) return JsonHelp.GetJsonContent(0, "该求购信息不存在");

            return Mapper.Map<DataBuyInfo>(buyinfo);
        }

        /// <summary>
        /// 根据用户id查询订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [Route("GetBuyInfoByUserId/{userid}")]
        [Describe("求购发布", "通过传递userid参数，即可放回该用户发布的所有信息")]
        [HttpGet]
        public object GetBuyInfoByUserId(string userid)
        {
            if (!ApiVerification.VerificationNull(userid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            var userinfo = this._iUserInfoService.Where(o => o.UserId.ToString() == userid).FirstOrDefault();
            if (userinfo == null) return JsonHelp.GetJsonContent(0, "该用户不存在");

            return Mapper.Map<List<DataBuyInfo>>(userinfo.BuyInfo.ToList());
        }
    }
}
