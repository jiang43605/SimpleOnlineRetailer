using System.Linq;
using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the ProductInfo Service
    /// </summary>
    public partial class ProductInfoService:BaseService<ProductInfo>,IProductInfoService
    {
        protected override IBaseDal<ProductInfo> _BaseDal
        {
           get { return this._dalSession.GetProductInfoDal; }
        }
    }
    
}
