using BankLoanAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BankLoanAppMVC.Controllers
{
    public class AdminController : Controller
    {
        private AppDBContext db = new AppDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admins)
        {


            var obj = db.Admins
                    .Where(a => a.AdminName.Trim() == admins.AdminName &&
                                a.Password.Trim() == admins.Password).FirstOrDefault();

            if (obj != null)
            {
                Session["AdminName"] = obj.AdminName.ToString();


                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "User not found for given Email and Password";
                return View();
            }

        
            
            

    }

            
        
        


        public ActionResult ChangeStatus()
        {
            
                return View(db.Loans.ToList());

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loans = db.Loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Status = "Approved";
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChangeStatus");
            }
            return View(loan);
        }

        public ActionResult Decline(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loans = db.Loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Decline(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Status = "Declined";
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChangeStatus");
            }
            return View(loan);
        }

        public ActionResult ViewCustomers()
        {
            
            
                return View(db.Customers.ToList());
            
            
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
           
            Customer customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();

            Loan loans = db.Loans.Where(s => s.CustomerID == id).FirstOrDefault();
            db.Loans.Remove(loans);
            db.SaveChanges();

            return RedirectToAction("ViewCustomers");
        }



    }
}