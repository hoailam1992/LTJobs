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

    public partial class message :ModelBase
    {
      
        [DataMember]
        public string from { get; set; }
        [DataMember]
        public long to { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string body { get; set; }
        [DataMember]
        public System.DateTime datetime { get; set; }
        [DataMember]
        public bool status { get; set; }
        [DataMember]
        public Nullable<bool> isdeleted { get; set; }
        [DataMember]

        public virtual user user { get; set; }
    }
}
