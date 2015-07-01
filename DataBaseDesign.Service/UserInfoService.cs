using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the UserInfo Service
    /// </summary>
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        protected override IBaseDal<UserInfo> _BaseDal
        {
           get { return this._dalSession.GetUserInfoDal; }
        }
    }
    
}
