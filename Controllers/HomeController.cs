using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDBHandler handler = new UserDBHandler();
                    if (handler.Login(login))
                    {
                        //set session
                        Session["email"] = login.Email.Trim();
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.error = "Login Failed";
                        return RedirectToAction("Login");
                    }
                }
            }
            catch
            {
                return View(login);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDBHandler handler = new UserDBHandler();
                    if (handler.RegisterUser(user))
                    {
                        ModelState.Clear();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.error = "Email Already Exists";
                        return View();
                    }
                }
            }
            catch
            {
                return View(user);
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear(); //remove session
            return RedirectToAction("Login");
        }
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["email"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}