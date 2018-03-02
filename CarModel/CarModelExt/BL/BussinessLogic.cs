using CarModelExt.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarModelExt.BL
{
    public class BussinessLogic: IBussinessLogic
    {
        public bool IsLogged()=>HttpContext.Current.User.Identity.IsAuthenticated;
    
        public string GetUserName()
        {
            
            string userName="Unlogged user";
            if (IsLogged())
            {
                userName = HttpContext.Current.User.Identity.Name;
            }
            return userName;
        }
    }
}