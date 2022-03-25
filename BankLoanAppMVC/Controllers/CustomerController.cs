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
    public class CustomerController : Controller
    {
        public int idval;
        private AppDBContext db = new AppDBContext();
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer model)
        {


            var obj = db.Customers
                        .Where(a => a.Email.Trim() == model.Email &&
                                    a.Password.Trim() == model.Password).FirstOrDefault();

            if (obj != null)
            {
                Session["UserID"] = obj.CustomerID.ToString();
                Session["Email"] = obj.Email.ToString();
                idval = Convert.ToInt16(Session["UserID"]);
                ViewBag.Message = "Login Successfully.!";
                return View();
            }
            else
            {
                ViewBag.Message = "User not found for given Email and Password";
                return View();
            }


        }

        public ActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer user)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(user);
                db.SaveChanges();
                ViewBag.Message = "Registered Successfully";
                return View();
            }

            return View();

        }


        public ActionResult LoanApply()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult LoanApply(Loan loan)
        {


            if (ModelState.IsValid)
            {
                loan.CustomerID = Convert.ToInt32(Session["UserID"]);
                loan.Status = "OnProgress..!!";
                db.Loans.Add(loan);
                db.SaveChanges();
                ViewBag.Message = "Applied Successfully";
                return View();
            }

            return View();

        }







        public ActionResult LoanStatus()
        {
            if (Session["UserID"] != null)
            {
                return View(db.Loans.ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


    }
}