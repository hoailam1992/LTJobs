//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using Models.Common;
    using System.Runtime.Serialization;

    public partial class report : ModelBase
    {
       
        [DataMember]
        public long bookingid { get; set; }
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public string systemrespond { get; set; }
        [DataMember]
        public Nullable<decimal> refundamount { get; set; }
        [DataMember]

        public virtual booking booking { get; set; }
    }
}
