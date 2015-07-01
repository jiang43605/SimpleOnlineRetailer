using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Common;
using DataBaseDesign.IDal;

namespace DataBaseDesign.DalFactory
{
    /// <summary>
    /// 创建IDalSession的实例
    /// </summary>
    public static class DalSessionFac
    {
        private const string _DalSessionAssemblyUrl = "DalSessionAssemblyUrl";
        private const string _DalSessionInstanceName = "DalSessionInstanceName";
        /// <summary>
        /// 获得DalSession对象
        /// </summary>
        /// <returns></returns>
        public static IDalSession GetDalSession()
        {
            // 首先检查配置文件是否指定了应加载的程序集
            IDalSession dalSession1 = CreatInstanceHelp.CreatInstanceByConfigOnlyUserAssemblyName<IDalSession>(_DalSessionAssemblyUrl, _DalSessionInstanceName);
            return dalSession1 ?? new DalSession();
        }
    }
}
