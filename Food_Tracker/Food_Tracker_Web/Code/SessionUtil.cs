using Food_Tracker_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Tracker_Web.Code
{
    public class SessionUtil
    {
        public static SessionUtil Ins
        {
            get
            {
                return new SessionUtil();
            }
        }
        public tblUser User
        {
            get
            {
                return HttpContext.Current.Session["User"] as tblUser;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }
    }
}