using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using APIService.Controllers;
using AutoMapper;
using DataBaseDesign.Cache;
using DataBaseDesign.DalFactory;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;
using DataBaseDesign.Model;
using DataBaseDesign.Service;
using Memcached.ClientLibrary;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductInfoService productInfo = new ProductInfoService();
            IProviderService providerService = new ProviderService();
            var provider = providerService.Where(o => o.Account == "alibaba").FirstOrDefault();
            ProductInfo p = new ProductInfo
            {
                PdId = Guid.NewGuid(),
                PdName = "测试",
                PdNum = 10,
                ProductDescribe = "这是测试商品",
                PdPrice = 23,
                SubTime = DateTime.Now,
            };
            p.Provider.Add(provider);
          bool bl =  productInfo.Add(p);
            bl.ToString();


            string[] serverlist = { "127.0.0.1:11211" };

            //初始化池
            //SockIOPool pool = SockIOPool.GetInstance();
            //pool.SetServers(serverlist);

            //pool.InitConnections = 3;
            //pool.MinConnections = 3;
            //pool.MaxConnections = 5;

            //pool.SocketConnectTimeout = 1000;
            //pool.SocketTimeout = 3000;

            //pool.MaintenanceSleep = 30;
            //pool.Failover = true;

            //pool.Nagle = false;
            //pool.Initialize();

            //MemcachedClient mc = new MemcachedClient {EnableCompression = false};
            ////mc.Set("haha", "你好啊");
            //Console.WriteLine(mc.Delete("hahasas"));


            //SockIOPool.GetInstance().Shutdown();

            #region 3
            RedisCache<ProductInfo> yu = new ProductInfoRCache();

            var ds = yu.Get("fd2deada-2bbd-4d27-a77f-cbb9412b3c81");
            Console.WriteLine(ds);
            //UserInfo userInfo = new UserInfo
            //{
            //    UserId = Guid.NewGuid(),
            //    Name = "chengfisgod"
            //};
            var client = new RedisClient();
            
            //Console.WriteLine(userInfo.Name);
            // //Console.WriteLine(client.Get<string>("dasda"));
            client.Set("bcbf0c5b-8450-4988-b61b-f140c4d27a4e", "dasdsa");
            // //Console.WriteLine(client.GetAllEntriesFromHash("userid")["name"]);
            // //client.RemoveEntry("userid");
            // //Console.WriteLine(client.Get<UserInfo>("haha").Name);
            //int i = client.Exists("haha");
            //bool blk = client.Set("haha", userInfo);
            //int i1 = client.Exists("haha");
            //bool bl = client.Remove("haha");
            //bool bl1 = client.Remove("haha");
            // bool bl = client.SetEntryIfNotExists("haha", "fdsds");
            //bl.ToString();
            //blk.ToString();
            //Console.WriteLine(i+i1+bl1.ToString());
            // bool yu = client.ExpireEntryIn("haha", TimeSpan.FromSeconds(10));
            // Console.WriteLine(yu);
            // while (client.Exists("haha")!=0)
            // {
            //     Console.WriteLine("还未过期");
            //     Thread.Sleep(1000);
            // }
            // client.Set("haha", userInfo);
            // Console.WriteLine("过期了已经.....");

            //Console.WriteLine(client.Host);
            //Console.WriteLine(client.Port);
            //Console.WriteLine(client.Get<UserInfo>("haha").Name);


            #endregion

            #region 2

            //Type userType = typeof(UserInfoController);
            //var test = userType.GetMethods();
            //string pre = userType.GetCustomAttribute<RoutePrefixAttribute>().Prefix;
            //var t1 = test.Select(o => o.GetCustomAttribute<RouteAttribute>()).TakeWhile(o => o != null);
            //foreach (var routeAttribute in t1)
            //{
            //    Console.WriteLine(pre+"\\"+routeAttribute.Template);
            //} 

            #endregion
            #region 1

            //UserInfo h3 = JsonConvert.DeserializeObject<UserInfo>("{}");

            //Mapper.CreateMap<UserInfo, DataUserInfo>();
            //Mapper.CreateMap<DataUserInfo, UserInfo>();

            //string jk = Guid.NewGuid().ToString();
            //jk.ToString();

            //DataBaseDesignModelContainer data = new DataBaseDesignModelContainer();
            //var userInfo = data.UserInfo.FirstOrDefault();
            //DataUserInfo ytu = Mapper.Map<DataUserInfo>(userInfo);

            //string h1 = JsonConvert.SerializeObject(ytu);
            //UserInfo h2 = JsonConvert.DeserializeObject<UserInfo>(h1);


            //UserInfo ytu1 = Mapper.Map<UserInfo>(ytu);
            //Console.WriteLine(h3);
            //ProductEvaluate product = new ProductEvaluate
            //{
            //    EvaTime = DateTime.Now,
            //    Item = "很不错啊",
            //    PdId = Guid.Parse("bbd563de-960c-42f5-8e6c-c9711f1120ee"),
            //    SubTime = DateTime.Now,
            //    ProductEvaId = Guid.NewGuid(),
            //    UserId = Guid.Parse("e9709190-33ef-4e12-9117-c2d2ab798fc1"),
            //};

            //data.ProductEvaluate.Add(product);

            //data.SaveChanges();
            //var hg = data.UserInfo.ToList();
            //hg.ToString();

            //IQueryable<UserInfo> yud = data.UserInfo.Where(o => o.Account == "das");
            //List<UserInfo> yud1 = yud.OrderBy(o => o.Account).ToList();
            //Console.WriteLine(yud1);

            //string yu = Guid.NewGuid().ToString();
            //Console.WriteLine(yu);
            //IDalSession dalSession = DalSessionFac.GetDalSession();
            //IUserInfoDal chengf = dalSession.GetUserInfoDal;
            //chengf.Add(new UserInfo
            //{
            //    Age = 18,
            //    Name = "chengf",
            //    Phone = "18911423650",
            //    Sex = false,
            //    UserId = Guid.NewGuid(),
            //    RegisteTime = DateTime.Now,
            //    SubTime = DateTime.Now
            //});
            //int num = dalSession.SavaChanges();
            //if (num > 0) Console.WriteLine("OK!");
            //Console.ReadKey(); 

            #endregion
            Console.ReadKey();
        }
    }
}
