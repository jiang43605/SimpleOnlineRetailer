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
    /// the BuyInfo api
    /// </summary>
    [RoutePrefix("api/restful/BuyInfo")]
    public partial class BuyInfoController : ApiController
    {
       private IBuyInfoService _iBuyInfoService { set; get; }
    
       /// <summary>
       /// 承载缓存实现的对象
       /// </summary>
       private RedisCache<DataBuyInfo> _RedisCache { get { return new BuyInfoRCache(); } }
    }
    
}
