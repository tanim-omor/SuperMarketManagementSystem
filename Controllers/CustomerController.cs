using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;

namespace Final_Project.Controllers
{

    public class CustomerController : Controller
    {
        // GET: Customer
        ShopManagementSystemEntitiesx db = new ShopManagementSystemEntitiesx();
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer([Bind(Exclude = "")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return View();
            }
            return View();
        }

        public ActionResult DeleteCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCustomer(int UserID)
        {
            Customer customer = db.Customers.Where(temp => temp.CustomerId == UserID).FirstOrDefault();
            db.Customers.Remove(customer);
            db.SaveChanges();
            ViewBag.customers = db.Customers.ToList();
            return View();
        }
    }
}