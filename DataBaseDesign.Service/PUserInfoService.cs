using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Model;

namespace DataBaseDesign.Service
{
    public partial class UserInfoService
    {
        /// <summary>
        /// 添加一个新的用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool CreatAccount(UserInfo userInfo)
        {
            return this.Add(userInfo);
        }
    }
}
