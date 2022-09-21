using LoginPage.DataDb;
using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        Usb_GetStudentEntities2 obj = new Usb_GetStudentEntities2();
        public ActionResult Index()
        {
            var res = obj.UserLoginsucsesses.ToList();
            return View(res);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpData a)
        {
            UserLoginsucsess obj2 = new UserLoginsucsess();
            obj2.UserId = a.UserId;
            obj2.First_Name = a.First_Name;
            obj2.Last_Name = a.Last_Name;
            obj2.Email = a.Email;
            obj2.Password = a.Password;
            obj2.Phone_Number = a.Phone_Number;
            obj2.Practice_Field = a.Practice_Field;
            obj2.Role = a.Role;
            if (obj2.UserId == 0)
            {
                obj.UserLoginsucsesses.Add(obj2);
                obj.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                obj.Entry(obj2).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
                return RedirectToAction("Create");

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginsucsess loginClass)
        {
            if (ModelState.IsValid)
            {
                var result = obj.UserLoginsucsesses.Where(opt => opt.Email.Equals(loginClass.Email) && opt.Password.Equals(loginClass.Password)).FirstOrDefault();
                if (result != null)
                {
                    return RedirectToAction("Create", "Home");
                }
                ViewData["LoginId"] = " invalid UserName or Password";
                return View();
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Create");
        }


    }
}

        

