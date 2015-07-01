using System;
using DataBaseDesign.Model;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// the OrderInfo Cache in redis
    /// </summary>
    public class OrderInfoRCache:RedisCache<DataOrderInfo>
    {
    	protected override TimeSpan _TimeSpan 
    	{ 
    		get
    		{
    		   return TimeSpan.FromMinutes(5);
    		}
    	}
    }
    
}
