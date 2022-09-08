using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        List<cart> productList = new List<cart>();
        ShopManagementSystemEntitiesx db = new ShopManagementSystemEntitiesx();

        Customer customer;

        List<Customer> customers = new List<Customer>();

        int cusid = -1;

        List<cart> carts = new List<cart>()
        {
            new cart(){ProductName = "Bullet"}
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCart()
        {
            ViewBag.customer = new Customer();
            C_current_ x = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();

            x.customer = null;

            db.SaveChanges();
            return View();

        }
        [HttpPost]
        public ActionResult AddCart(int cusid)
        {
            var sql = "select * from Customer where CustomerId = " + cusid;
            Customer customer = db.Customers.Where(temp => temp.CustomerId == cusid).FirstOrDefault();
            if (customer == null)
            {
                customer = db.Customers.Where(temp => temp.CustomerId == 123000).FirstOrDefault();
                cusid = 123000;
            }
            if(cusid <=0) cusid = 123000;
            ViewBag.customer = customer;
            this.customer = customer;
            C_current_ x = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();

            x.customer = (""+cusid);

            db.SaveChanges();
            return View();

        }

        [HttpPost]
        public ActionResult Redir()
        {
            ViewBag.customer = this.customer;
            C_current_ c = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();
            if(c.customer != null)
                return RedirectToAction("AddCart2", "Cart");
            else
                return RedirectToAction("AddCart", "Cart");
            //if (this.customer!=null)
            //    return RedirectToAction("AddCart2", "Cart");
            //else
            //    return RedirectToAction("AddCart", "Cart");
        }


        public ActionResult AddCart2()
        {
            var sqlx = "select * from Product";

            List<Product> pList = db.Products.SqlQuery(sqlx).ToList();

            ViewBag.prods = pList;

            var a = pList[0].ProductName;

            C_current_ x = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();

            x.customer = null;

            db.SaveChanges();

            return View();

        }

        [HttpPost]
        public ActionResult AddCart2(FormCollection fc, String createTime, String ProductId, String ProductName, String Counts, int? cusid)
        {
            var action = fc["action"];

            if (action == "Set")
            {
                var sql = "select * from Customer where CustomerId = " + cusid;
                Customer customer = db.Customers.Where(temp => temp.CustomerId == cusid).FirstOrDefault();
                if (customer == null)
                {
                    customer = db.Customers.Where(temp => temp.CustomerId == 123000).FirstOrDefault();
                    cusid = 123000;
                }
                if (cusid <= 0) cusid = 123000;

                customers.Add(customer);
                ViewBag.Customer = customers;
                ViewBag.Customerx = customers;
                this.cusid = Convert.ToInt32(cusid);
                string s = customer.CustomerName;
                this.customer = customer;

                C_current_ x = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();
                x.customer = ("" + cusid);
                db.SaveChanges();

                db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();





            }
            else if (action == "Add")
            {


            }
            if (action == "Submit")
            {
                C_current_ x = db.C_current_.Where(temp => temp.indx == 10001).FirstOrDefault();
                var a = Convert.ToInt32(x.customer);
            }

            return View();
        }

        public ActionResult SetCartCustomer(string cusid)
        {
            return View();
        }
        
    }
}