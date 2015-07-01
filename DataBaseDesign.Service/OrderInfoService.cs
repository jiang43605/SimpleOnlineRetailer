using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the OrderInfo Service
    /// </summary>
    public partial class OrderInfoService:BaseService<OrderInfo>,IOrderInfoService
    {
        protected override IBaseDal<OrderInfo> _BaseDal
        {
           get { return this._dalSession.GetOrderInfoDal; }
        }
    }
    
}
