using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()


        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //here we are getting the customer's birth month
            //it will determine how much money they retire with
            if (customer.BirthMonth >= 1 && customer.BirthMonth <= 4)
            {
                ViewBag.Money = 1000000;
            }
            else if (customer.BirthMonth >= 5 && customer.BirthMonth <= 8)
            {
                ViewBag.Money = 5000;
            }
            else if (customer.BirthMonth >= 9 && customer.BirthMonth <= 12)
            {
                ViewBag.Money = 79000;
            }
            else
            {
                ViewBag.Money = 0;
            }

            //next we are asking the customer for their favorite ROYGBIV color
            //it determines their transportation

            if (customer.FavoriteColor.ToUpper() == "RED")
            {
                ViewBag.Transport = "bike";
            }
            else if (customer.FavoriteColor.ToUpper() == "ORANGE")
            {
                ViewBag.Transport = "horse";
            }
            else if (customer.FavoriteColor.ToUpper() == "YELLOW")
            {
                ViewBag.Transport = "ferryboat";
            }
            else if (customer.FavoriteColor.ToUpper() == "GREEN")
            {
                ViewBag.Transport = "rikshaw";
            }
            else if (customer.FavoriteColor.ToUpper() == "BLUE")
            {
                ViewBag.Transport = "VW Bug";
            }
            else if (customer.FavoriteColor.ToUpper() == "INDIGO")
            {
                ViewBag.Transport = "Piggy Back Ride";
            }
            else if (customer.FavoriteColor.ToUpper() == "VIOLET")
            {
                ViewBag.Transport = "limo";
            }

            //this determines the customer's retirement age based on their current age

            if (customer.Age % 2 == 0)

            {
                ViewBag.Retirement = 78;
            }
            else
            {
                ViewBag.Retirement = 23;
            }

            //this determind their vacationhome depending on the amount of siblings the customer has
            if (customer.NumberofSiblings == 0)
            {
                ViewBag.VacationHome = "an arm pit";
            }
            else if (customer.NumberofSiblings == 1)
            {
                ViewBag.VacationHome = "Brussels";
            }
            else if (customer.NumberofSiblings == 2)
            {
                ViewBag.VacationHome = "a cave";
            }
            else if (customer.NumberofSiblings == 3)
            {
                ViewBag.VacationHome = "a wolf's den";
            }
            else if (customer.NumberofSiblings >= 4)
            {
                ViewBag.VacationHome = "a basement";
            }
            else
                ViewBag.VacationHome = "Antartica";
              


            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberofSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberofSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
