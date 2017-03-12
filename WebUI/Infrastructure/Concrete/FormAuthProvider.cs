﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using System.Web.Security;

namespace WebUI.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool res = FormsAuthentication.Authenticate(username, password);
            if (res)
                FormsAuthentication.SetAuthCookie(username, false);
            return res;
        }
    }
}