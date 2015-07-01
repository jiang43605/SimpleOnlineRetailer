using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the SellInfo Service
    /// </summary>
    public partial class SellInfoService:BaseService<SellInfo>,ISellInfoService
    {
        protected override IBaseDal<SellInfo> _BaseDal
        {
           get { return this._dalSession.GetSellInfoDal; }
        }
    }
    
}
