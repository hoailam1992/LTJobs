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

    public partial class moneytransaction : ModelBase
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public byte[] receiptphoto { get; set; }
        [DataMember]
        public decimal value { get; set; }
        [DataMember]
        public System.DateTime trandate { get; set; }
        [DataMember]
        public string remark { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public long sourceid { get; set; }
        [DataMember]
        public long destinationid { get; set; }
        [DataMember]
        public Nullable<System.DateTime> paymentdate { get; set; }
        [DataMember]
        public string ccname { get; set; }
        [DataMember]
        public string ccno { get; set; }
        [DataMember]
        public Nullable<int> ccexpiredmonth { get; set; }
        [DataMember]
        public Nullable<int> ccexpiredyear { get; set; }
        [DataMember]
        public string ccpin { get; set; }
        [DataMember]
        public System.DateTime createddate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> modifieddate { get; set; }
        [DataMember]

        public virtual user user { get; set; }
        [DataMember]
        public virtual user user1 { get; set; }
    }
}
