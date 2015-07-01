using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Model;

namespace DataBaseDesign.IService
{
    public partial interface IUserInfoService
    {
        /// <summary>
        /// 创建一个新帐号
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        bool CreatAccount(UserInfo userInfo);
    }
}
