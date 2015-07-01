using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the BuyInfo Service
    /// </summary>
    public partial class BuyInfoService:BaseService<BuyInfo>,IBuyInfoService
    {
        protected override IBaseDal<BuyInfo> _BaseDal
        {
           get { return this._dalSession.GetBuyInfoDal; }
        }
    }
    
}
