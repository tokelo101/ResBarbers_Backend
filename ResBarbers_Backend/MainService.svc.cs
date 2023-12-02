using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ResBarbers_Backend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    
    public class MainService : IMainService
    {
        MainDataClassesDataContext db = new MainDataClassesDataContext();

        public bool RegisterUser(USER_ barber)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }
        
    }
}
