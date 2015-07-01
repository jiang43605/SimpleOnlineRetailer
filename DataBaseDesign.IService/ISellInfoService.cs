using DataBaseDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.IService
{
    /// <summary>
    /// the SellInfo Service interface
    /// </summary>
    public partial interface ISellInfoService:IBaseService<SellInfo>
    {
        /// <summary>
        /// �����ϼ���Ʒ����ϸ��Ϣ��ȡsellinfo�ļ���
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<SellInfo> GetProductByDescribe(string key);
    }
    
}
