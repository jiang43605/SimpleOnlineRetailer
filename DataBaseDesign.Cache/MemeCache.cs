using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Common;
using Memcached.ClientLibrary;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// MemeCache实现方式，在全局最后记得关闭SockIOPool.GetInstance().Shutdown();
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MemeCache<T> : ICache<T>
    {
        private readonly MemcachedClient _memcached = new MemcachedClient { EnableCompression = false };
        static MemeCache()
        {
            var otherserverlist = ReadConfigHelp.GetAppSettingsVualeUseSplit("ServerList", ',');
            otherserverlist.Add("127.0.0.1:11211");
            string[] serverlist = otherserverlist.ToArray();

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();
        }
        public bool Set(string key, T value)
        {
            return this._memcached.Set(key, value);
        }

        /// <summary>
        /// 可以设置延时失效的添加方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool Set(string key, T value, DateTime dateTime)
        {
            return this._memcached.Set(key, value, dateTime);
        }

        public T Get(string key)
        {
            return (T)this._memcached.Get(key);
        }

        public bool Remove(string key)
        {
            return !this._memcached.KeyExists(key) || this._memcached.Delete(key);
        }
    }
}
