using BusinessLayer.Service;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLibrary
{
    [ServiceBehavior]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public partial class MasterService : IMasterService
    {
        public List<Dictionary<string, object>> ExecuteStoreQuery(string storeProc, Dictionary<string, object> paras)
        {
            return (new UserBusinessService()).ExecuteStoreQuery(storeProc, paras);
        }
        public List<Dictionary<string, object>> ExecuteQuery(string storeProc)
        {
            return (new UserBusinessService()).ExecuteQuery(storeProc);
        }
    }
}
