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
        private SqlConnection connect;
        private void Connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            connect = new SqlConnection(connection);
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
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