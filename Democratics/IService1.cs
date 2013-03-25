using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Democratics
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string GetWriteData(int value);

        //Users
        [OperationContract]
        int RegisterNewUser(User usr);

        [OperationContract]
        int AddUserInfoToUser(UserInfo usr_info);

        [OperationContract]
        int UpdateUserInfoForUser(UserInfo usr_info);

        [OperationContract]
        UserInfo GetUserInfoForUser(User usr);

        [OperationContract]
        bool IsItMe(string UsrName);

        //Admin
        [OperationContract]
        User GetUserWithID(int id);

        [OperationContract]
        List<User> GetAllUsers();

    }
}
