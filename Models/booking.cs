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
    public partial class Booking:ModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.Reports = new HashSet<Report>();
            this.Trackings = new HashSet<Tracking>();
        }
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long ClientId { get; set; }
        [DataMember]
        public long ProductId { get; set; }
        [DataMember]
        public Nullable<long> DeliveryId { get; set; }
        [DataMember]
        public Nullable<decimal> ProductPrice { get; set; }
        [DataMember]
        public Nullable<decimal> DeliveryPrice { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public decimal TotalCost { get; set; }
        [DataMember]
        public long ProductType { get; set; }
        [DataMember]
        public string ProductRespond { get; set; }
        [DataMember]
        public string DeliveryRespond { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateTime { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public Nullable<bool> IsDeleted { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
        [DataMember]
        public Nullable<decimal> ProductValue { get; set; }
        [DataMember]
        public Nullable<decimal> DeliveryValue { get; set; }
        [DataMember]
        public Nullable<long> TrackingId { get; set; }
        [DataMember]

        public virtual Client Client { get; set; }
        [DataMember]
        public virtual Delivery Delivery { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
        [DataMember]
        public virtual Tracking Tracking { get; set; }
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tracking> Trackings { get; set; }
    }
}
