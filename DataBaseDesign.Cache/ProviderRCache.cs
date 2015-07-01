using System;
using DataBaseDesign.Model;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// the Provider Cache in redis
    /// </summary>
    public class ProviderRCache:RedisCache<DataProvider>
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
