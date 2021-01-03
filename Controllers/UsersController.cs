using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,Password,Firstname,Lastname,Email,Address,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();


            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,Password,Firstname,Lastname,Email,Address,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(ViewModels.UserViewModel model)
        {
            if (!db.Users.Any(x => x.User_ID == model.User_ID))
            {
                User Userrecord = new User();
                Userrecord.User_ID = model.User_ID;
                Userrecord.Firstname = model.Firstname;
                Userrecord.Lastname = model.Lastname;
                Userrecord.Password = model.Password;
                Userrecord.Email = model.Email;
                db.Users.Add(Userrecord);
                db.SaveChanges();

                string smtpServer = "smtp.gmail.com";
                string fromMail = model.Email;
                string fromPassword = model.Password;
                string subject = "Successful sign up!";
                string mailBody = "mabrook ya a5oya";
                Helpers.MailManager.SendMail(subject, mailBody, fromMail, fromPassword, model.Email, smtpServer, 587);


                return RedirectToAction("Index", "Home");
            }
            else if (db.Users.Any(x => x.User_ID == model.User_ID))
            {
                ModelState.AddModelError("User_ID", "User already registered. Try again");
            }


            return View(model);
        }

        public ActionResult Signup()
        {
            return View();
        }


        public ActionResult Signin(ViewModels.UserViewModel model)
        {
            User foundUser = db.Users.Find(model.User_ID);

            if (foundUser == null)
                return View(model);
            else
            {
                if (foundUser.Password.TrimEnd(' ') == model.Password)
                {
                    if (foundUser.User_Type.TrimEnd(' ') == "AuthorizedUser")
                    {
                        // needs to be authorized
                    }
                    else
                    {
                        // needs to be staff
                    }

                }

                return View(model);
        }
    }


        public ActionResult Signin()
        {
            return View();
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



        

