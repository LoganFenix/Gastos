using Modelos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GastosBootStrap.Seguridad
{
    public class CustomPrincipal:IPrincipal
    {
        //private UserAccount Account;
        //private UserAccount UA = new UserAccount();

        public CustomPrincipal(string username)
        {

            //this.Account = UA.find



        }
        public IIdentity Identity
        {
          
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}