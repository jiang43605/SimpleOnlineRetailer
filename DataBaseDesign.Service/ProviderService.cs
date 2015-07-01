using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the Provider Service
    /// </summary>
    public partial class ProviderService:BaseService<Provider>,IProviderService
    {
        protected override IBaseDal<Provider> _BaseDal
        {
           get { return this._dalSession.GetProviderDal; }
        }
    }
    
}
