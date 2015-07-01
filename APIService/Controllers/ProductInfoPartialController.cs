using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIService.Models;
using AutoMapper;
using DataBaseDesign.Cache;
using DataBaseDesign.IService;
using DataBaseDesign.Model;

namespace APIService.Controllers
{
    public partial class ProductInfoController
    {
        private IProviderService _iProviderService { set; get; }
        /// <summary>
        /// 添加一个商品根据供应商ID，使用Post(json)
        /// </summary>
        /// <param name="providerid"></param>
        /// <returns></returns>
        [Route("AddProduct/{providerid}")]
        [Describe("商品表", "添加一个商品根据供应商ID，请使用Post(json)，需要price（价格），name（名称），decribe（描述）、num（数量）这几个必须Key")]
        [HttpPost]
        public HttpResponseMessage AddProduct(string providerid)
        {
            if (!ApiVerification.VerificationNull(providerid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            var provider = this._iProviderService.Where(o => o.ProviderId.ToString() == providerid).FirstOrDefault();
            if (provider == null) return JsonHelp.GetJsonContent(0, "没有此供应商");

            var newproduct = PostHelp.GetPostInstance<ProductInfo>();
            if (!ApiVerification.VerificationNull(newproduct.PdName, newproduct.ProductDescribe))
                return JsonHelp.GetJsonContent(0, "必要的商品参数不能为空");

            newproduct.PdId = Guid.NewGuid();
            newproduct.SubTime = DateTime.Now;
            newproduct.Provider.Add(provider);

            // 缓存
            this._RedisCache.Set(newproduct.PdId.ToString(), Mapper.Map<DataProductInfo>(newproduct));

            return this._iProductInfoService.Add(newproduct)
                ? JsonHelp.GetJsonContent(200, "添加成功")
                : JsonHelp.GetJsonContent(0, "添加失败");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        [Route("DeleteProduct/{productid}")]
        [Describe("商品表", "请使用Get请求，传递过来一个productid，将对其进行软删除")]
        [HttpGet]
        public HttpResponseMessage DeleteProduct(string productid)
        {
            if (!ApiVerification.VerificationNull(productid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            var product = this._iProductInfoService.Where(o => o.PdId.ToString() == productid).FirstOrDefault();
            if (product == null) return JsonHelp.GetJsonContent(0, "没有此商品");
            product.IsDelete = true;

            // 缓存
            this._RedisCache.Set(productid, Mapper.Map<DataProductInfo>(product));

            return this._iProductInfoService.UpdataEntry(product)
                ? JsonHelp.GetJsonContent(200, "删除成功")
                : JsonHelp.GetJsonContent(0, "删除失败");
        }

        /// <summary>
        /// 根据json数据修改
        /// </summary>
        /// <returns></returns>
        [Route("UpdataProduct")]
        [Describe("商品表", "更新操作，请使用POST请求，必要参数PdName、PdPrice、ProductDescribe、PdNum")]
        [HttpPost]
        public HttpResponseMessage UpdataProduct()
        {
            ProductInfo productInfo = PostHelp.GetPostInstance<ProductInfo>();
            if (productInfo == null) return JsonHelp.GetJsonContent(0, "Json格式出错");

            var dataproduct = this._iProductInfoService.Where(o => o.PdId == productInfo.PdId).FirstOrDefault();
            if (dataproduct == null) return JsonHelp.GetJsonContent(0, "商品不存在");

            dataproduct.PdName = productInfo.PdName;
            dataproduct.PdPrice = productInfo.PdPrice;
            dataproduct.ProductDescribe = productInfo.ProductDescribe;
            dataproduct.PdNum = productInfo.PdNum;
            dataproduct.SubTime = DateTime.Now;

            // 修改缓存
            this._RedisCache.Set(dataproduct.PdId.ToString(), Mapper.Map<DataProductInfo>(dataproduct));

            return this._iProductInfoService.UpdataEntry(dataproduct)
                ? JsonHelp.GetJsonContent(200, "修改成功")
                : JsonHelp.GetJsonContent(0, "修改失败");
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        [Route("GetProduct/{productid}")]
        [Describe("商品表", "请使用Get请求，根据ID值来查询获得")]
        [HttpGet]
        public object GetProduct(string productid)
        {
            if (!ApiVerification.VerificationNull(productid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            // 先检查缓存
            DataProductInfo dataproduct = this._RedisCache.Get(productid);
            if (dataproduct != null) return dataproduct;

            ProductInfo product = this._iProductInfoService.Where(o => o.PdId.ToString() == productid).FirstOrDefault();
            if (product == null) return JsonHelp.GetJsonContent(0, "没有此商品");

            return Mapper.Map<DataProductInfo>(product);
        }

        /// <summary>
        /// Get请求，根据供应商账户，返回其所有商品
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [Route("GetProducByProviderId/{account}")]
        [Describe("商品表", "Get请求，根据供应商账户，返回其所有商品")]
        [HttpGet]
        public object GetProducByProviderId(string account)
        {
            if (!ApiVerification.VerificationNull(account))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            var provider = this._iProviderService.Where(o => o.Account.ToString() == account).FirstOrDefault();
            if (provider == null) return JsonHelp.GetJsonContent(0, "此供应商不存在");

            return Mapper.Map<List<DataProductInfo>>(provider.ProductInfo);
        }
    }
}
