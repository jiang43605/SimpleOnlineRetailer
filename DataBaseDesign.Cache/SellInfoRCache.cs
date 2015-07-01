using System;
using DataBaseDesign.Model;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// the SellInfo Cache in redis
    /// </summary>
    public class SellInfoRCache:RedisCache<DataSellInfo>
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
