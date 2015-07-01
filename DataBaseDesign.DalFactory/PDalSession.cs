 
using System;
using System.IO;
using DataBaseDesign.IDal;
using DataBaseDesign.Common;

namespace DataBaseDesign.DalFactory
{
	internal partial class DalSession
	{
		// 读取默认的本地文件
        private static readonly string _AssemblyUrl = "DataBaseDesign.Dal.dll";
	
		/// <summary>
        /// 获得IApiAuthorityVerificationDal的实例
        /// </summary>
		public IApiAuthorityVerificationDal GetApiAuthorityVerificationDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IApiAuthorityVerificationDal>(_AssemblyUrl, "DataBaseDesign.Dal.ApiAuthorityVerificationDal");
			}
		}	
	
		/// <summary>
        /// 获得IBuyInfoDal的实例
        /// </summary>
		public IBuyInfoDal GetBuyInfoDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IBuyInfoDal>(_AssemblyUrl, "DataBaseDesign.Dal.BuyInfoDal");
			}
		}	
	
		/// <summary>
        /// 获得IOrderInfoDal的实例
        /// </summary>
		public IOrderInfoDal GetOrderInfoDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IOrderInfoDal>(_AssemblyUrl, "DataBaseDesign.Dal.OrderInfoDal");
			}
		}	
	
		/// <summary>
        /// 获得IProductEvaluateDal的实例
        /// </summary>
		public IProductEvaluateDal GetProductEvaluateDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IProductEvaluateDal>(_AssemblyUrl, "DataBaseDesign.Dal.ProductEvaluateDal");
			}
		}	
	
		/// <summary>
        /// 获得IProductInfoDal的实例
        /// </summary>
		public IProductInfoDal GetProductInfoDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IProductInfoDal>(_AssemblyUrl, "DataBaseDesign.Dal.ProductInfoDal");
			}
		}	
	
		/// <summary>
        /// 获得IProviderDal的实例
        /// </summary>
		public IProviderDal GetProviderDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IProviderDal>(_AssemblyUrl, "DataBaseDesign.Dal.ProviderDal");
			}
		}	
	
		/// <summary>
        /// 获得ISellInfoDal的实例
        /// </summary>
		public ISellInfoDal GetSellInfoDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<ISellInfoDal>(_AssemblyUrl, "DataBaseDesign.Dal.SellInfoDal");
			}
		}	
	
		/// <summary>
        /// 获得IUserInfoDal的实例
        /// </summary>
		public IUserInfoDal GetUserInfoDal
		{
			get
			{
				 return CreatInstanceHelp.CreatInstanceByUrlOnlyUserAssemblyName<IUserInfoDal>(_AssemblyUrl, "DataBaseDesign.Dal.UserInfoDal");
			}
		}	
	}
}