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

    public partial class photo : ModelBase
    {
        
        [DataMember]
        public long userid { get; set; }
        [DataMember]
        public byte[] data { get; set; }
        [DataMember]
        public string photolink { get; set; }
        [DataMember]
        public System.DateTime uploadeddate { get; set; }
        [DataMember]
        public string photodescription { get; set; }
        [DataMember]
        public System.DateTime createddate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> modifieddate { get; set; }
        [DataMember]
        public Nullable<bool> isvisble { get; set; }
        [DataMember]
        public Nullable<bool> vipmemberonly { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]

        public virtual user user { get; set; }
    }
}
