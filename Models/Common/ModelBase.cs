using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract(IsReference = true)]
    public abstract class ModelBase
    {
        #region General Properties
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public ModelState ModelState { get; set; }
        #endregion

        #region ctor and Initialize
        public ModelBase()
        {
           
        }


        #endregion
    }
}
