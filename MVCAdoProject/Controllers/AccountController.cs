using MVCAdoProject.Models;
using MVCAdoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAdoProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        MyRepository myRepository = new MyRepository();

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {

            if (user.UserName!=null||user.Password!=null)
            {
                Users isUser = myRepository.isUserData(user.UserName, user.Password);
                if (isUser.UserId==0 || isUser.UserName==null)
                {

                    ViewBag.Error = "No user record found";
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        
        
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}