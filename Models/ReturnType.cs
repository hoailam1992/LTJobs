using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract(Name = "ReturnTypeOf{0}")]
    public class ReturnType<T>
    {
        public ReturnType()
        {
            IsSuccess = false;
            ErrorMessage ="No data Tranfer";
        }
        public ReturnType(T t)
        {
            Result = t;
            IsSuccess = false;
            ErrorMessage = "No data Tranfer";
        }
        //Return value
        [DataMember]
        public bool IsSuccess { get; set; }
        //Return message
        [DataMember]
        public string ErrorMessage { get; set; }
        //Return dataset
        [DataMember]
        public T Result { get; set; }
    }
}
