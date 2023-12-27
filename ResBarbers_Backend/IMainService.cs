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
        bool RegisterUser(USER_ user);

        [OperationContract]
        int Login(string email, string password);

        [OperationContract]
        string GetUserType(int UserID);

        [OperationContract]
        bool AddHairstyle(MenuItem StyleID);

        [OperationContract]
        bool RemoveHairstyle(int StyleID);

        [OperationContract]
        bool EditHairstyle(int StyleID, MenuItem Hairstyle);

        [OperationContract]
        MenuItem GetHairstyle(int StyleID);

        [OperationContract]
        List<MenuItem> GetBarberHairstyles(int BarberID);

        [OperationContract]
        List<MenuItem> GetAllHairstyles();

        [OperationContract]
        USER_ GetUser(int UserID);

        [OperationContract]
        List<USER_> GetUsers(string UserType);
    }
}
