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

    public partial class deliverytype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public deliverytype()
        {
            this.deliveryprices = new HashSet<deliveryprice>();
        }

        [DataMember]
        public long deliveryid { get; set; }
        [DataMember]
        public long deliverycode { get; set; }
        [DataMember]
        public string deliverydescription { get; set; }
        [DataMember]
        public bool active { get; set; }
        [DataMember]
        public string extrafee { get; set; }
        [DataMember]
        public System.DateTime createddate { get; set; }
        [DataMember]
        public System.DateTime modifieddate { get; set; }
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deliveryprice> deliveryprices { get; set; }
        [DataMember]
        public virtual delivery delivery { get; set; }
    }
}
