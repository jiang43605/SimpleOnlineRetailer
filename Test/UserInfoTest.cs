using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [DisplayName("你好啊")]
    public class UserInfoTest
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <param name="userid"></param>
        [AsyncStateMachine(typeof(UserInfoTest))]
        [DisplayName("你好啊")]
        public void ReleaseBuyInfo(string userid)
        {

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="buyInfoid"></param>
        /// <returns></returns>

        public void DeleteBuyInfo(string buyInfoid)
        {

        }

        /// <summary>
        /// 根据json数据修改
        /// </summary>
        /// <returns></returns>

        public void UpdataBuyInfo()
        {

        }

        /// <summary>
        /// 根据用户id查询订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>

        public void GetBuyInfo(string userid)
        {

        }
    }
}
