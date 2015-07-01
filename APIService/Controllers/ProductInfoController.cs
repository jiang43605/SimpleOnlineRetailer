using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APIService.Models;
using DataBaseDesign.IService;
using DataBaseDesign.Model;
using DataBaseDesign.Cache;

namespace APIService.Controllers
{
    /// <summary>
    /// the ProductInfo api
    /// </summary>
    [RoutePrefix("api/restful/ProductInfo")]
    public partial class ProductInfoController : ApiController
    {
       private IProductInfoService _iProductInfoService { set; get; }
    
       /// <summary>
       /// 承载缓存实现的对象
       /// </summary>
       private RedisCache<DataProductInfo> _RedisCache { get { return new ProductInfoRCache(); } }
    }
    
}
