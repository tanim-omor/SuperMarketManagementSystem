using Final_Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class E_HomeController : Controller
    {
        // GET: E_Home

        ShopManagementSystemEntitiesx db = new ShopManagementSystemEntitiesx();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Products()
        {
            var sql = "select * from Product";
            List<Product> pList = db.Products.SqlQuery(sql).ToList();
            return View(pList);
        }

        public ActionResult Cart()
        {
            var sql = "select * from Cart";
            List<cart> pList = db.carts.SqlQuery(sql).ToList();
            return View(pList);
        }
        public ActionResult Customer()
        {
            var sql = "select * from Customer";
            List<Customer> pList = db.Customers.SqlQuery(sql).ToList();
            return View(pList);
        }



    }
}