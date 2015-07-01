using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the ProductEvaluate Service
    /// </summary>
    public partial class ProductEvaluateService:BaseService<ProductEvaluate>,IProductEvaluateService
    {
        protected override IBaseDal<ProductEvaluate> _BaseDal
        {
           get { return this._dalSession.GetProductEvaluateDal; }
        }
    }
    
}
