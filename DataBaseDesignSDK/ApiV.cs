using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesignSDK
{
    public static class ApiV
    {
        public static bool IsNull(params string[] strings)
        {
            return strings.Any(string.IsNullOrEmpty);
        }

        public static ResponseMsg EMsg()
        {
            return new ResponseMsg { StatusCode = 0, Message = "参数不能为空" };
        }
    }
}
