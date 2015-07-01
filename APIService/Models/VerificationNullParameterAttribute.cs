using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIService.Models
{
    public class VerificationNullParameterAttribute:Attribute
    {
        private readonly string[] _paramameter;

        public VerificationNullParameterAttribute(params string[] paramameter)
        {
            this._paramameter = paramameter;
        }

        /// <summary>
        /// 内容不能为空的参数集合
        /// </summary>
        public string[] Paramameter
        {
            get { return _paramameter; }
        }
    }
}