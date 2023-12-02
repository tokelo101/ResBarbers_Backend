using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ResBarbers_Backend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract]
    
    public interface IMainService
    {
        [OperationContract]
        bool RegisterUser(USER_ barber);
        bool Login(string email, string password);
    }
}
