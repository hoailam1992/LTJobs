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
    [DataContract(IsReference = true)]
    public partial class booking : ModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public booking()
        {
            this.reports = new HashSet<report>();
        }
       
        [DataMember]
        public long clientid { get; set; }
        [DataMember]
        public long productid { get; set; }
        [DataMember]
        public Nullable<long> deliveryid { get; set; }
        [DataMember]
        public Nullable<decimal> productprice { get; set; }
        [DataMember]
        public Nullable<decimal> deliveryprice { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string paymentmode { get; set; }
        [DataMember]
        public decimal totalcost { get; set; }
        [DataMember]
        public long producttype { get; set; }
        [DataMember]
        public string productrespond { get; set; }
        [DataMember]
        public string deliveryrespond { get; set; }
        [DataMember]
        public Nullable<System.DateTime> datetime { get; set; }
        [DataMember]
        public Nullable<System.DateTime> createddate { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public Nullable<bool> isdeleted { get; set; }
        [DataMember]
        public System.DateTime modifieddate { get; set; }
        [DataMember]

        public virtual client client { get; set; }
        [DataMember]
        public virtual delivery delivery { get; set; }
        [DataMember]
        public virtual product product { get; set; }
        [DataMember]
        public virtual ICollection<report> reports { get; set; }
    }
}
