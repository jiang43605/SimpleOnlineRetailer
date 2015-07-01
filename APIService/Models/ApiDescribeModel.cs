using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIService.Models
{
    /// <summary>
    /// api描述模型
    /// </summary>
    public class ApiDescribeModel
    {
        /// <summary>
        /// 用于a标签url导航
        /// </summary>
        public string ViewApiUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ApiUrl) || this.Glyphicon == "glyphicon glyphicon-remove-circle glyphicon-color-red")
                    return "javascript:void(0);";
                string view = ApiUrl.Replace("{", "").Replace("}", "");
                return view;
            }
        }
        /// <summary>
        /// 用于url文字说明
        /// </summary>
        public string ApiUrl { set; get; }
        /// <summary>
        /// 描述api的文字
        /// </summary>
        public string DescribeItem { set; get; }
        /// <summary>
        /// 描述标题
        /// </summary>
        public string Head { set; get; }
        /// <summary>
        /// 标题前的是否可用图标
        /// </summary>
        public string Glyphicon { set; get; }
    }
}