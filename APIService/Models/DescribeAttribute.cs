using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIService.Models
{
    /// <summary>
    /// api描述标签
    /// </summary>
    public class DescribeAttribute : Attribute
    {
        private readonly string _describeItem;
        private readonly string _describeHead;
        private readonly bool _canuse;

        public DescribeAttribute(string describehead, string describeitem, bool canuse = true)
        {
            _describeHead = describehead;
            _describeItem = describeitem;
            _canuse = canuse;
        }

        /// <summary>
        /// 具体描述文本
        /// </summary>
        public string DescribeItem
        {
            get { return _describeItem; }
        }

        /// <summary>
        /// 标头
        /// </summary>
        public string DescribeHead
        {
            get { return _describeHead; }
        }

        /// <summary>
        /// 表示是否可用
        /// </summary>
        public bool CanUse
        {
            get { return _canuse; }
        }

        /// <summary>
        /// 标题的图标
        /// </summary>
        public string Glyphicon
        {
            get
            {
                return this._canuse
                    ? "glyphicon glyphicon-ok-circle glyphicon-color-green"
                    : "glyphicon glyphicon-remove-circle glyphicon-color-red";
            }
        }
    }
}