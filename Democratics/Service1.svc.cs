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
using System.Threading;

namespace Democratics
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public string GetWriteData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

       /// <summary>
       /// Users Managment
       /// </summary>
       /// <param name="Type"></param>
       /// <param name="UserName"></param>
       /// <returns></returns>


        //User
        public int RegisterNewUser(User usr)
        {
            dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
            if (usr.type == 0)
            {
                if (dataContext.Users.Count(c => c.username == usr.username) ==0)
                {
                    dataContext.Users.Add(usr);
                    return dataContext.SaveChanges();
                }
                else
                {
                    return -100;
                }
            }
            else
            {
                //User cannot create different roles then users!
                return -999;
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public int AddUserInfoToUser(UserInfo usr_info)
        {
            User usr = GetUserWithID(usr_info.user_id);
            if (usr != null)
            {
                if (IsItMe(usr.username))
                {
                    dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
                    dataContext.UserInfoes.Add(usr_info);
                    return dataContext.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public int UpdateUserInfoForUser(UserInfo usr_info)
        {
            User usr = GetUserWithID(usr_info.user_id);
            if (usr != null)
            {
                if (IsItMe(usr.username))
                {
                    dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
                    UserInfo info= dataContext.UserInfoes.First(c => c.user_id == usr.id);
                    info.meno = usr_info.meno;
                    info.p_meno = usr_info.p_meno;
                    info.priezvisko = usr_info.priezvisko;
                    info.p_priezvisko = usr_info.p_priezvisko;
                    info.email = usr_info.email;
                    info.p_email = usr_info.p_email;
                    return dataContext.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public UserInfo GetUserInfoForUser(User usr)
        {
            if (IsItMe(usr.username))
            {
                dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
                return dataContext.UserInfoes.First(c => c.user_id == usr.id);
            }
            else
            {
                return null;
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public bool IsItMe(string UsrName)
        {
            IPrincipal ip = Thread.CurrentPrincipal;
            if (ip.Identity.Name == UsrName)
            {
                return true;
            }
            return false;
        }

        //Admin
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public User GetUserWithID(int id)
        {
            dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
            return dataContext.Users.Where(c => c.id == id).First();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public List<User> GetAllUsers()
        {
            dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 dataContext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
            return dataContext.Users.ToList();
        }
    }
}
