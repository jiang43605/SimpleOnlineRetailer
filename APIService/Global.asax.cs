using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using DataBaseDesign.Model;
using Spring.Web.Mvc;

namespace APIService
{
    public class WebApiApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            DTOMap();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// DTO层数据映射
        /// </summary>
        private static void DTOMap()
        {
            Mapper.CreateMap<ApiAuthorityVerification, DataApiAuthorityVerification>();
            Mapper.CreateMap<DataApiAuthorityVerification, ApiAuthorityVerification>();

            Mapper.CreateMap<BuyInfo, DataBuyInfo>();
            Mapper.CreateMap<DataBuyInfo, BuyInfo>();

            Mapper.CreateMap<OrderInfo, DataOrderInfo>();
            Mapper.CreateMap<DataOrderInfo, OrderInfo>();

            Mapper.CreateMap<ProductEvaluate, DataProductEvaluate>();
            Mapper.CreateMap<DataProductEvaluate, ProductEvaluate>();

            Mapper.CreateMap<ProductInfo, DataProductInfo>();
            Mapper.CreateMap<DataProductInfo, ProductInfo>();

            Mapper.CreateMap<Provider, DataProvider>();
            Mapper.CreateMap<DataProvider, Provider>();

            Mapper.CreateMap<SellInfo, DataSellInfo>();
            Mapper.CreateMap<DataSellInfo, SellInfo>();

            Mapper.CreateMap<UserInfo, DataUserInfo>();
            Mapper.CreateMap<DataUserInfo, UserInfo>();
        }
    }
}
