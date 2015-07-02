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
    public partial class OrderInfoController
    {
        private IUserInfoService _iUserInfoService { set; get; }
        private ISellInfoService _iSellInfoService { set; get; }
        private IProductInfoService _iProductInfoService { set; get; }
        /// <summary>
        /// 创建一个订单
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sellid"></param>
        /// <returns></returns>
        [Route("AddOrderInfo/{userid}/{sellid}")]
        [Describe("订单", "需要userid和sellid参数来产生一个订单")]
        [HttpGet]
        public HttpResponseMessage AddOrderInfo(string userid, string sellid)
        {

            var userInfo = this._iUserInfoService.Where(o => o.UserId.ToString() == userid).FirstOrDefault();
            if (userInfo == null) return JsonHelp.GetJsonContent(0, "没有此用户");

            var sellinfo = this._iSellInfoService.Where(o => o.SellId.ToString() == sellid).FirstOrDefault();
            if (sellinfo == null) return JsonHelp.GetJsonContent(0, "没有此商品");

            var productInfo = this._iProductInfoService.Where(o => o.PdId == sellinfo.PdId).FirstOrDefault();
            if (productInfo == null) return JsonHelp.GetJsonContent(0, "商品数据和上架商品数据出现不一致");
            if (productInfo.PdNum <= 0) return JsonHelp.GetJsonContent(0, "商品已经售罄");

            OrderInfo orderInfo = new OrderInfo
            {
                CreatTime = DateTime.Now,
                IsConfirm = false,
                OrderId = Guid.NewGuid(),
                SellId = sellinfo.SellId,
                UserId = userInfo.UserId,
                SubTime = DateTime.Now
            };

            // 缓存
            this._RedisCache.Set(orderInfo.OrderId.ToString(), Mapper.Map<DataOrderInfo>(orderInfo));

            if (this._iOrderInfoService.Add(orderInfo))
            {
                productInfo.PdNum--;
                this._iProductInfoService.UpdataEntry(productInfo);
                return JsonHelp.GetJsonContent(200, "添加成功");
            }
            return JsonHelp.GetJsonContent(0, "添加失败");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [Route("DeleteOrderInfo/{orderId}")]
        [Describe("订单", "根据orderid参数删除指定的订单")]
        [HttpGet]
        public HttpResponseMessage DeleteOrderInfo(string orderId)
        {

            var product = this._iOrderInfoService.Where(o => o.OrderId.ToString() == orderId).FirstOrDefault();
            if (product == null) return JsonHelp.GetJsonContent(0, "没有此订单");

            // 更新缓存
            this._RedisCache.Remove(orderId);

            return this._iOrderInfoService.DeleteEntry(product)
                ? JsonHelp.GetJsonContent(200, "删除成功")
                : JsonHelp.GetJsonContent(0, "删除失败");
        }

        /// <summary>
        /// 查找单个订单的信息
        /// </summary>
        /// <param name="orederid"></param>
        /// <returns></returns>
        [Route("GetOrderInfoById/{orederid}")]
        [Describe("订单", "通过orederid来查询此订单信息")]
        [HttpGet]
        public object GetOrderInfoById(string orederid)
        {
            // 缓存中取数据
            DataOrderInfo dataorderinfo = this._RedisCache.Get(orederid);
            if (dataorderinfo != null) return dataorderinfo;

            OrderInfo orderinfo = this._iOrderInfoService.Where(o => o.OrderId.ToString() == orederid).FirstOrDefault();
            if (orderinfo == null) return JsonHelp.GetJsonContent(0, "该订单不存在");

            return Mapper.Map<DataOrderInfo>(orderinfo);
        }

        /// <summary>
        /// 根据用户id查询订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [Route("GetOrderInfo/{userid}")]
        [Describe("订单", "通过userid来查询此用户的所有订单")]
        [HttpGet]
        public object GetOrderInfoByUserId(string userid)
        {

            var orderinfo = this._iUserInfoService.Where(o => o.UserId.ToString() == userid).FirstOrDefault();
            if (orderinfo == null) return JsonHelp.GetJsonContent(0, "该用户不存在");

            return Mapper.Map<List<DataOrderInfo>>(orderinfo.OrderInfo.ToList());
        }
    }
}
