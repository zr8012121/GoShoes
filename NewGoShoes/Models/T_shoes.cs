//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewGoShoes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_shoes
    {
        public T_shoes()
        {
            this.T__ordersDetail = new HashSet<T__ordersDetail>();
        }
    
        public int shoesId { get; set; }
        public string shoesName { get; set; }
        public decimal shoesPrice { get; set; }
        public string shoesInfo { get; set; }
        public string shoesImg { get; set; }
        public int shoesScore { get; set; }
        public int shoesTypeId { get; set; }
    
        public virtual ICollection<T__ordersDetail> T__ordersDetail { get; set; }
        public virtual T_shoesType T_shoesType { get; set; }
    }
}
