using DLL.FunctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpKeep.Models.MainMaster;

namespace UpKeep.Utility
{
    public static class SessionDetails
    {
        private const string LoggedInUser = "LoggedInUser";
        private const string LoggedInClient = "LoggedInClient";
        public static Client ClientSession
        {
            get
            {
                Client userAuth = (Client)HttpContext.Current.Session[LoggedInClient];
                return userAuth;
            }
            set
            {
                HttpContext.Current.Session[LoggedInClient] = value;
            }
        }

        public static User_Login_Master_Property UserSession
        {
            get
            {
                User_Login_Master_Property userAuth = (User_Login_Master_Property)HttpContext.Current.Session[LoggedInUser];
                return userAuth;
            }
            set
            {
                HttpContext.Current.Session[LoggedInUser] = value;
            }
        }
    }
}