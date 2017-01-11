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
    public partial class ClientComment : ModelBase
    {
       
        [DataMember]
        public long ClientId { get; set; }
        [DataMember]
        public Nullable<long> ProductId { get; set; }
        [DataMember]
        public Nullable<long> DeliveryId { get; set; }
        [DataMember]
        public Nullable<int> Rate { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        [DataMember]

        public virtual Client Client { get; set; }
        [DataMember]
        public virtual Delivery Delivery { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
    }
}
