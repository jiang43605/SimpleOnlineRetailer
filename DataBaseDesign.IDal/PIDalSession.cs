 
using DataBaseDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.IDal
{
	/// <summary>
	/// IDalSession的部分类
	/// </summary>
	public partial interface IDalSession
    {
	
		/// <summary>
		/// 获得ApiAuthorityVerification对象
		/// </summary>	
		IApiAuthorityVerificationDal GetApiAuthorityVerificationDal{get;}
	
		/// <summary>
		/// 获得BuyInfo对象
		/// </summary>	
		IBuyInfoDal GetBuyInfoDal{get;}
	
		/// <summary>
		/// 获得OrderInfo对象
		/// </summary>	
		IOrderInfoDal GetOrderInfoDal{get;}
	
		/// <summary>
		/// 获得ProductEvaluate对象
		/// </summary>	
		IProductEvaluateDal GetProductEvaluateDal{get;}
	
		/// <summary>
		/// 获得ProductInfo对象
		/// </summary>	
		IProductInfoDal GetProductInfoDal{get;}
	
		/// <summary>
		/// 获得Provider对象
		/// </summary>	
		IProviderDal GetProviderDal{get;}
	
		/// <summary>
		/// 获得SellInfo对象
		/// </summary>	
		ISellInfoDal GetSellInfoDal{get;}
	
		/// <summary>
		/// 获得UserInfo对象
		/// </summary>	
		IUserInfoDal GetUserInfoDal{get;}
	}
}