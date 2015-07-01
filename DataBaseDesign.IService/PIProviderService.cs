using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Model;

namespace DataBaseDesign.IService
{
    public partial interface IProviderService
    {
        /// <summary>
        /// 创建一个新的帐号
        /// </summary>
        /// <returns></returns>
        bool CreatAccount(Provider provider);
    }
}
