using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]    
    public partial interface IMasterService
    {
        [OperationContract]
        List<Dictionary<string, object>> ExecuteStoreQuery(string storeProc, Dictionary<string, object> paras);
        [OperationContract]
        List<Dictionary<string, object>> ExecuteQuery(string storeProc);
    }

}
