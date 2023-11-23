﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenshinCourse.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(user objCheck)
        {
            if (ModelState.IsValid)
            {
                using (GenshinCourse_dbEntities db = new GenshinCourse_dbEntities())
                {
                    var obj = db.users.Where(a => a.uname.Equals(objCheck.uname) && a.password.Equals(objCheck.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.uname.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }
                }
            }
            return View(objCheck);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}