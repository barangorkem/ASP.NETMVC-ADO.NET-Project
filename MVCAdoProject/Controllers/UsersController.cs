using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAdoProject.Models;
using MVCAdoProject.Repository;
namespace MVCAdoProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        // GET: Users
        
        public ActionResult Index()
        {
            UserRepository userlist = new UserRepository();
            return View(userlist.ListUsers());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            UserRepository userObject = new UserRepository();
            return View(userObject.FindUser(id));
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users user)
        {
            try
            {
                UserRepository userObject = new UserRepository();
               if(ModelState.IsValid)
                {
                    if (userObject.AddUser(user))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Bir hata oluştu.";
                        return View();
                    }

                    
                }
               else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            UserRepository userObject = new UserRepository();
           
             Users  user=userObject.FindUser(id);
                return View(user);

        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Users user)
        {
            UserRepository userObject = new UserRepository();
            try
            {
                userObject.UpdateUser(id, user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    

        // POST: Users/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                UserRepository userRepository = new UserRepository();
                userRepository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

       
    }
}
