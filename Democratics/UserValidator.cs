using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Democratics
{
    /// <summary>
    /// User Name Password Validator
    /// </summary>
    public class UserValidator
    {
        public bool IsUserValid(string userName, string password, out string commaSeparatedRoles)
        {
            commaSeparatedRoles = string.Empty;
            bool result = false;
            dbb8e2ff3f72c74b72880ca18a014fe9baEntities3 datacontext = new dbb8e2ff3f72c74b72880ca18a014fe9baEntities3();
            User usr = datacontext.Users.First(c => c.username == userName);
            if (usr != null)
            {
                if ((String.Equals(usr.password, password, StringComparison.Ordinal) == true))
                {
                    switch (usr.type)
                    {
                        case 0:
                            commaSeparatedRoles = @"User";
                            break;
                        case 1:
                            commaSeparatedRoles = @"User,Editor";
                            break;
                        case 999:
                            commaSeparatedRoles = @"User,Admin,Editor";
                            break;

                    }
                    result = true;
                }
                else
                {
                    new LogEvent("Wrong pass="+password+"..."+usr.password).Raise();
                }
            }
            else
            {
                new LogEvent("Usr=NULL Username="+userName).Raise();
            }
            
            return result;
        }
    }
}