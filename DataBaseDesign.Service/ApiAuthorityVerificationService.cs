using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the ApiAuthorityVerification Service
    /// </summary>
    public partial class ApiAuthorityVerificationService:BaseService<ApiAuthorityVerification>,IApiAuthorityVerificationService
    {
        protected override IBaseDal<ApiAuthorityVerification> _BaseDal
        {
           get { return this._dalSession.GetApiAuthorityVerificationDal; }
        }
    }
    
}
