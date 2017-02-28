using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


/// <summary>
/// Summary description for Models
/// </summary>
namespace WebEmpty.MasterService
{
    [DataContract(IsReference = true)]
    public class ProductItem
    {
        public ProductItem()
        {

        }
        public long Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public int Age { get; set;}
        public string Group { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public decimal Price { get; set; }
        public string PreferrableLocation { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public int CancelCount { get; set; }
        public long UserId { get; set; }
        public string ProductDescription { get; set; }
        public string DefaultImage { get; set; }
    }
}
