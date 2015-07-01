using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// Redis版本
    /// </summary>
    public abstract class RedisCache<T> : ICache<T>
    {
        protected RedisClient _RedisClient = RedisClientFac.GetInstanse();
        /// <summary>
        /// 默认定时时间设置
        /// </summary>
        protected abstract TimeSpan _TimeSpan { get; }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, T value)
        {
            try
            {
                return this._RedisClient.Set(key, value, this._TimeSpan);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 批量添加，用T的唯一主键作为key
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        //public abstract bool SetArrange(IEnumerable<T> list);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(string key)
        {
            return this._RedisClient.Get<T>(key);
        }

        /// <summary>
        /// 移除，成功移除或者本来就不存在时都返回true，只在因为其它错误导致失败时返回false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            int iexist = this._RedisClient.Exists(key);
            return iexist == 0 || this._RedisClient.Remove(key);
        }

        /// <summary>
        /// 是否存在判断
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return this._RedisClient.Exists(key) != 0;
        }

        /// <summary>
        /// 为指定key，改变过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public bool ChangeExpire(string key, TimeSpan timeSpan)
        {
            return this._RedisClient.ExpireEntryIn(key, timeSpan);
        }

    }


    /// <summary>
    /// Redis工厂
    /// </summary>
    public static class RedisClientFac
    {
        private static readonly RedisClient _RedisClient = new RedisClient();

        /// <summary>
        /// 获得实例
        /// </summary>
        /// <returns></returns>
        public static RedisClient GetInstanse()
        {
            return _RedisClient;
        }
    }
}
