using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;
using System.Web.Helpers;

namespace Final_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        ShopManagementSystemEntitiesx db = new ShopManagementSystemEntitiesx();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(String pin,String name,String email,String password)
        {
            adminPin apin = db.adminPins.Where(temp => temp.pin == pin).FirstOrDefault();
            if(apin == null)
            {
                return View();
            }
            else
            {
                db.adminPins.Remove(apin);

                string _otp = Convert.ToString((new Random()).Next(100000, 999999));
                auth na = new auth() { email = email, uname = name, pass = password,otp = _otp, verification = "no" };
                db.auths.Add(na);
                db.SaveChanges();


                String mailbody = "Hi " + name + ",\n" + "Your OTP is " + _otp + ".\n\nThank you";

                //WebMail.Send(email, "Yout OTP from Supermarket Management System", mailbody, null, null, null, true, null, null, null, null, null, null);

                return RedirectToAction("OTP", "Employee");
            }
            
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String email, String password)
        {
            auth au = db.auths.Where(temp => temp.email == email).FirstOrDefault();
            if(au!=null && au.pass == password && au.verification == "yes")
            {
                return RedirectToAction("Home", "E_Home");
            }
            else if(au != null && au.pass == password && au.verification == "no")
            {
                return RedirectToAction("OTP", "Employee");
            }
            return View();
        }
        public ActionResult partls()
        {
            return View();
        }
        public ActionResult OTP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OTP(String pin)
        {
            auth au = db.auths.Where(temp => temp.otp == pin).FirstOrDefault();
            if (au != null)
            {
                au.verification = "yes";
                au.otp = "Applied";
                db.SaveChanges();
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                return View();
            }
            
        }

    }
}