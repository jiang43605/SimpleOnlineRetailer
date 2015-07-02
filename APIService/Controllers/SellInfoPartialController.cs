using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APIService.Models;
using AutoMapper;
using DataBaseDesign.IService;
using DataBaseDesign.Model;
using Newtonsoft.Json;

namespace APIService.Controllers
{
    public partial class SellInfoController
    {

        private IProductInfoService _iProductInfoService { set; get; }

        /// <summary>
        /// 分页获得正在出售的商品表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [Route("GetSellInfoByPage/{pagesize}/{pageindex}")]
        [Describe("已上架商品", "针对已经上架的商品，需要填入pagesize（一页显示的数量），pageindex（第几页）参数")]
        [HttpGet]
        public object GetSellInfoByPage(string pagesize, string pageindex)
        {
            int index, size;
            bool tpindex = int.TryParse(pageindex, out index);
            bool tpsize = int.TryParse(pagesize, out size);
            if (!tpindex || !tpsize) return JsonHelp.GetJsonContent(0, "页码或页面大小只能为整数！");

            List<SellInfo> sellInfos = this._iSellInfoService.LoadPageEntities(index, size, o => true, o => o.PutawayTime, false).ToList();
            return Mapper.Map<List<DataSellInfo>>(sellInfos);
        }

        /// <summary>
        /// 根据sellid返回商品
        /// </summary>
        /// <param name="sellid"></param>
        /// <returns></returns>
        [Route("GetSellInfoById/{sellid}")]
        [Describe("已上架商品", "Get请求，根据上架商品ID来获得相应商品信息")]
        [HttpGet]
        public object GetSellInfoById(string sellid)
        {
            var s = this._iSellInfoService.Where(o => o.SellId.ToString() == sellid).FirstOrDefault();
            if (s == null) return JsonHelp.GetJsonContent(0, "该商品不存在");

            return Mapper.Map<DataSellInfo>(s);
        }

        /// <summary>
        /// 上架一件商品
        /// </summary>
        /// <param name="pdid"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        [Route("PutAway/{pdid}/{describe}")]
        [Describe("已上架商品", "上架一件新的商品，需要指定所属的商品id即pdid，以及对新商品的描述")]
        [HttpGet]
        public HttpResponseMessage PutAway(string pdid, string describe)
        {
            var productinfo = this._iProductInfoService.Where(o => o.PdId.ToString() == pdid).FirstOrDefault();
            if (productinfo == null) return JsonHelp.GetJsonContent(0, "尝试上架的商品在库中并未找到");

            SellInfo sellInfo = new SellInfo
            {
                SellId = Guid.NewGuid(),
                PdId = Guid.Parse(pdid),
                PutawayTime = DateTime.Now,
                Describe = describe,
                SubTime = DateTime.Now
            };

            // 缓存
            this._RedisCache.Set(sellInfo.SellId.ToString(), Mapper.Map<DataSellInfo>(sellInfo));

            return this._iSellInfoService.Add(sellInfo)
                ? JsonHelp.GetJsonContent(200, "添加成功")
                : JsonHelp.GetJsonContent(0, "添加失败");
        }

        /// <summary>
        /// 批次量的上架，接受json数据
        /// </summary>
        /// <returns></returns>
        [Route("BatchPutAway")]
        [Describe("已上架商品", "通过发送Post方法来批次上架")]
        [HttpPost]
        public HttpResponseMessage BatchPutAway()
        {
            try
            {
                List<SellInfo> sellInfos = PostHelp.GetPostInstance<List<SellInfo>>();
                if (sellInfos == null) return JsonHelp.GetJsonContent(0, "传入的json格式错误");
                return this._iSellInfoService.AddRange(sellInfos)
                    ? JsonHelp.GetJsonContent(200, "添加成功")
                    : JsonHelp.GetJsonContent(0, "添加失败");
            }
            catch
            {
                return JsonHelp.GetJsonContent(0, "出现未知异常，导致失败");
            }
        }

        /// <summary>
        /// 根据sellid下架商品
        /// </summary>
        /// <param name="sellid"></param>
        /// <returns></returns>
        [Route("OutAway/{sellid}")]
        [Describe("已上架商品", "下架一件商品根据sellid，注意这将直接删除而不是软删除")]
        [HttpGet]
        public HttpResponseMessage OutAway(string sellid)
        {
            var s = this._iSellInfoService.Where(o => o.SellId.ToString() == sellid).FirstOrDefault();
            if (s == null) return JsonHelp.GetJsonContent(0, "该商品未上过架");

            // 移除缓存
            this._RedisCache.Remove(sellid);

            return this._iSellInfoService.DeleteEntry(s)
                ? JsonHelp.GetJsonContent(200, "下架成功")
                : JsonHelp.GetJsonContent(0, "下架失败");

        }

        /// <summary>
        /// 根据关键字放回对应商品
        /// </summary>
        /// <param name="describe"></param>
        /// <returns></returns>
        [Route("GetProductByDescribe/{describe}")]
        [Describe("已上架商品", "Get请求，通过匹配描述里面的关键字，来返回相应的上架商品")]
        [HttpGet]
        public object GetProductByDescribe(string describe)
        {
            List<SellInfo> list = this._iSellInfoService.GetProductByDescribe(describe).ToList();
            return Mapper.Map<List<DataSellInfo>>(list);
        }
    }
}
