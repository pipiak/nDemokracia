using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Security.Permissions;
using System.ServiceModel.Activation;
using System.Security.Principal;
using System.ServiceModel.Channels;
namespace Democratics
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]
        public List<User> GetRecords()
        {
            dbb8e2ff3f72c74b72880ca18a014fe9baEntities1 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities1();
            return dataContext.Users.ToList();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Write")]
        public string GetWriteData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool AddNewUser(int Type, string UserName)
        {
            return true;
        }
    }
}
