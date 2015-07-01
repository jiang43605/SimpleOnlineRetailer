using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIService.Models;
using AutoMapper;
using DataBaseDesign.Model;

namespace APIService.Controllers
{
    public partial class ProductEvaluateController
    {
        /// <summary>
        /// 添加一个商品评论，使用Post(json)
        /// </summary>
        /// <returns></returns>
        [Route("AddProductEvaluate")]
        [Describe("商品评论（POST）","请使用POST请求，必须的KEY为：PdId（商品ID）、Item（评论内容）、UserId（用户ID）")]
        [HttpPost]
        public HttpResponseMessage AddProductEvaluate()
        {
            ProductEvaluate productEvaluate = PostHelp.GetPostInstance<ProductEvaluate>();

            var dataproductEvaluate = this._iProductEvaluateService.Where(o => o.ProductEvaId == productEvaluate.ProductEvaId).FirstOrDefault();
            if (dataproductEvaluate != null) return JsonHelp.GetJsonContent(0, "评论已经存在");

            productEvaluate.ProductEvaId = Guid.NewGuid();
            productEvaluate.EvaTime = DateTime.Now;
            productEvaluate.SubTime = DateTime.Now;

            return this._iProductEvaluateService.Add(productEvaluate)
                ? JsonHelp.GetJsonContent(200, "添加成功")
                : JsonHelp.GetJsonContent(0, "添加失败");
        }

        /// <summary>
        /// 根据商品Id返回该商品的所有评论
        /// </summary>
        /// <returns></returns>
        [Route("GetProductEvaluateByPdId/{pdid}")]
        [Describe("商品评论", "Get请求，根据商品的pdid，来返回该商品下的所有评论，这个商品id可以来自上架表中")]
        [HttpGet]
        public object GetProductEvaluateByPdId(string pdid)
        {
            if (!ApiVerification.VerificationNull(pdid))
                return JsonHelp.GetJsonContent(0, "参数不能为空");

            var dataproductEvaluate = this._iProductEvaluateService.Where(o => o.PdId.ToString() == pdid).ToList();
            return dataproductEvaluate;
        }

    }
}
