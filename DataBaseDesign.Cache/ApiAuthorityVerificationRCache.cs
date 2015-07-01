using System;
using DataBaseDesign.Model;

namespace DataBaseDesign.Cache
{
    /// <summary>
    /// the ApiAuthorityVerification Cache in redis
    /// </summary>
    public class ApiAuthorityVerificationRCache:RedisCache<DataApiAuthorityVerification>
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
