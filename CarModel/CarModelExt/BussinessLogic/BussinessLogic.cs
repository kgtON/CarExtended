using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarModelExt.BussinessLogic
{
    public class BussinessLogic
    {
        public bool isLogged()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }

        public string getUserName()
        {
            string userName="Unlogged user";
            if (isLogged())
            {
                userName = HttpContext.Current.User.Identity.Name;
            }
            return userName;
        }
    }
}