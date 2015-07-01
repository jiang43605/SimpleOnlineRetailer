using System;
using DataBaseDesign.Model;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// the ProductEvaluate Cache in redis
    /// </summary>
    public class ProductEvaluateRCache:RedisCache<DataProductEvaluate>
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
