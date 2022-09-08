using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ShopManagementSystemEntitiesx db = new ShopManagementSystemEntitiesx();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult DeleteProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteProduct(string pid)
        {
            Product product = db.Products.Where(temp => temp.ProductId == pid).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            ViewBag.customers = db.Customers.ToList();
            return View();
        }


        public ActionResult AddProduct()
        {
            return View();
        }

        bool checkNameFormat(String text)
        {
            bool nameOk = false;
            if (text == "" || text.Contains("  "))
            {
                return false;
            }
            nameOk = true;
            foreach (char c in text)
            {
                nameOk &= (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == ' ';
            }
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (text[i] == ' ')
                {
                    text.Remove(i, 1);
                }
            }

            return nameOk;
        }

        [HttpPost]
        public ActionResult AddProduct([Bind(Include = "ProductId, ProductName, PricePerUnit, ExpiryDate, UnitSold")] Product product)
        {
            if (ModelState.IsValid )
            {
                db.Products.Add(product);
                db.SaveChanges();
                return View();
            }
            return View();
        }
        public ActionResult FindProduct()
        {
            var sql = "select * from Product";
            List<Product> pList = db.Products.SqlQuery(sql).ToList();
            return View(pList);
        }

        [HttpPost]
        public ActionResult FindProduct(String id_equal_to,
            String id_less_than,
            String id_greater_than,
            String productName_equal_to,
            String productName_contains,
            String price_equal_to,
            String price_less_than,
            String price_greater_than,
            String expiry_equal_to,
            String expiry_less_than,
            String expiry_greater_than,
            String unit_equal_to,
            String unit_less_than,
            String unit_greater_than
            )
        {


            List<string> qlist = new List<string>();
            if (id_equal_to != "")
            {
                string temp = "(ProductId = '" + id_equal_to+"'";
                if (id_less_than != "")
                {
                    temp += (" or ProductId < '" + id_less_than + "'");
                }
                if (id_greater_than != "")
                {
                    temp += (" or ProductId > '" + id_greater_than + "'");
                }
                temp += ")";
                qlist.Add(temp);
            }
            else if (id_less_than != "")
            {
                qlist.Add("ProductId < '" + id_less_than + "'");
            }
            else if (id_greater_than != "")
            {
                qlist.Add("ProductId > '" + id_greater_than + "'");
            }
            if (productName_equal_to != "")
            {
                qlist.Add("ProductName = '" + productName_equal_to + "'");
            }
            if (productName_contains != "")
            {
                qlist.Add("ProductName like '%" + productName_contains + "%'");

            }
            if (price_equal_to != "")
            {
                string temp = ("(PricePerUnit = " + price_equal_to);
                if (price_less_than != "")
                {
                    temp += (" or PricePerUnit < " + price_less_than);
                }
                if (price_greater_than != "")
                {
                    temp += (" or PricePerUnit > " + price_greater_than);
                }
                temp += ")";
                qlist.Add(temp);
            }
            else if (price_less_than != "")
            {
                qlist.Add("PricePerUnit < " + price_less_than);
            }
            else if (price_greater_than != "")
            {
                qlist.Add("PricePerUnit > " + price_greater_than);
            }
            if (expiry_equal_to != "")
            {

            }
            if (expiry_less_than != "")
            {

            }
            if (expiry_greater_than != "")
            {

            }
            if (unit_equal_to != "")
            {
                string temp = ("(UnitSold = " + unit_equal_to);
                if (unit_less_than != "")
                {
                    temp += ("or UnitSold < " + unit_less_than);
                }
                if (unit_greater_than != "")
                {
                    temp += ("or UnitSold > " + unit_greater_than);
                }
                temp += ")";
                qlist.Add(temp);
            }
            else if (unit_less_than != "")
            {
                string temp = ("or UnitSold < " + unit_less_than);
                qlist.Add(temp);
            }
            else if (unit_greater_than != "")
            {
                string temp = ("or UnitSold > " + unit_greater_than);
                qlist.Add(temp);
            }
            var s = "select * from Product where ProductId is not NULL";
            foreach (var t in qlist)
            {
                s += (" and " + t);
            }
            List<Product> pList = db.Products.SqlQuery(s).ToList();
            return View(pList);
        }
    }
}