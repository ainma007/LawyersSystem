using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models;
using System.Web.Security;

namespace LawyersApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            ViewBag.PM = "© 1998-2016 PCDCR- Mohammed El-Habbash , All Rights Reserved";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users_Table user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    using (LawyersEntities dc = new LawyersEntities())
                    {
                        // Check If Existed Or Not : 
                        var u = dc.Users_Table.Single(i => i.UserName == user.UserName
                                                                    && i.Password == user.Password && i.Status == true);
                        if (u != null)
                        {

                            Session["UserID"] = u.UserID;
                            Session["UserName"] = u.FullName;
                            Session["Password"] = u.Password;
                            Session["UserType"] = u.UserType;



                            return RedirectToAction("Index", "Home");



                            //  User Informations : 



                        }
                    }

                }
                catch (Exception)
                {
                    //اذا كان المستخدم اساسا مش موجود في جدول المستخدمين او كلمة المرور خطأ
                    ModelState.AddModelError("", "خطأ في الدخول للنظام");
                }
            }
            return View(user);
        }




        public ActionResult LoggedIn()
        {
            ViewBag.Message = "Welcome ";
            return View();

        }

        public ActionResult LogOff()
        {

            // Set User OfLine  :
            //  SetUserOffLine();

            // to destroy the FormsAuthentication cookie 
            // حذف الكويكزز
            Session["ID"] = null;
            Session.Clear();
            FormsAuthentication.SignOut();

            //----------------------------
            return RedirectToAction("Login", "Account");
        }
    }
}