//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseDesign.Model
{
    using System;
    public class DataBuyInfo
    {
        public System.Guid BuyId { get; set; }
        public System.Guid UserId { get; set; }
        public string RequireProduceName { get; set; }
        public System.DateTime DurationTime { get; set; }
        public string Remark { get; set; }
        public System.DateTime SubTime { get; set; }
        public string Describe { get; set; }
        public bool IsDelete { get; set; }
    }
}
