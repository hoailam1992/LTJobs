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
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Report : ModelBase
    {
       
        [DataMember]
        public long BookingId { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string SystemRespond { get; set; }
        [DataMember]
        public Nullable<decimal> RefundAmount { get; set; }
        [DataMember]
        public virtual Booking Booking { get; set; }
    }
}
