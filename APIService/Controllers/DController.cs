using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIService.Models;

namespace APIService.Controllers
{
    public class DController : Controller
    {
        // GET: D
        public ActionResult Index()
        {
            ApiDescribeModel[] list = ApiUrlHelp.GetApiUrlList(
                typeof(UserInfoController),
                typeof(SellInfoController),
                typeof(ProductInfoController),
                typeof(ProviderController),
                typeof(ProductEvaluateController),
                typeof(BuyInfoController),
                typeof(OrderInfoController));
            return View(list);
        }
    }
}