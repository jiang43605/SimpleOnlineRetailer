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
    /// the Provider api
    /// </summary>
    [RoutePrefix("api/restful/Provider")]
    public partial class ProviderController : ApiController
    {
       private IProviderService _iProviderService { set; get; }
    
       /// <summary>
       /// 承载缓存实现的对象
       /// </summary>
       private RedisCache<DataProvider> _RedisCache { get { return new ProviderRCache(); } }
    }
    
}
