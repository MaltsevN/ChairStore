using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        // GET: Account
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Login or password is uncorrect.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}