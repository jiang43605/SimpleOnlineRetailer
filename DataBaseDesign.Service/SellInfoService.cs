using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DataBaseDesign.Model;
using DataBaseDesign.IDal;
using DataBaseDesign.IService;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// the SellInfo Service
    /// </summary>
    public partial class SellInfoService : BaseService<SellInfo>, ISellInfoService
    {
        protected override IBaseDal<SellInfo> _BaseDal
        {
            get { return this._dalSession.GetSellInfoDal; }
        }


        public List<SellInfo> GetProductByDescribe(string key)
        {
            const string sql = "select * from SellInfo where Describe like @key";
            return this._dalSession.SqlQuery<SellInfo>(sql, new SqlParameter("@key","%"+key+"%"));
        }
    }

}
