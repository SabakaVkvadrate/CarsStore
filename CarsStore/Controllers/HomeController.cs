using CarsStore.ViewModel;
using CarStoreDbEF.Entities;
using CarStoreDbEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarsStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User();
            user = (User)Session["LoggedUser"];

            if (user == null)
            {
                return RedirectToAction("Login");
            }
            else
               return RedirectToAction("StartPage", "Car");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository userRepository = new UserRepository();
            List<User> items = userRepository.GetAll(i => i.Username == model.UserName && i.Password == model.Password);

            object a = 1;// We use this object to provide some reference in Session ["IsLoggedUserAdmin"]
            if (items.Count > 0)
            {              
                Session["LoggedUser"] = items[0];
                Session["UserName"] = items[0].Firstname + " " + items[0].Lastname;

                if (items[0].IsAdmin)
                    Session["IsLoggedUserAdmin"] = a;
            }
            else
            {
                Session["LoggedUser"] = null;
                Session["IsLoggedUserAdmin"] = null;
            }

           if (items.Count <= 0)
               this.ModelState.AddModelError("failedLogin", "Login failed!");

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("StartPage", "Car");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout(LoginViewModel model)
        {                  
            Session["LoggedUser"] =  null;
            Session["IsLoggedUserAdmin"] = null;
            return RedirectToAction("Login", "Home");         
        }



    }
}