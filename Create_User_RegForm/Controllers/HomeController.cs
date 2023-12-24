using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Create_User_RegForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult About()
        {
            return View();
        } 
        public ActionResult Contact()
        {
            return View();
        } 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_UserReg userlogin)
        {
            MVCProjectDBContext db = new MVCProjectDBContext();
            var loginuser = db.tbl_UserReg.Where(x => x.UserName == userlogin.UserName && x.Password == userlogin.Password).Count();
            if(loginuser > 0)
            {
                return RedirectToAction("userList");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(tbl_UserReg user)
        {
            MVCProjectDBContext db =new MVCProjectDBContext();
            db.tbl_UserReg.Add(user);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("userList");  
        }
        public  ActionResult userList()
        {
            MVCProjectDBContext db = new MVCProjectDBContext();
            var user = db.tbl_UserReg.ToList();
            return View(user);
        }
        public ActionResult UserProfile(int id)
        {
            MVCProjectDBContext db = new MVCProjectDBContext();
            var user = db.tbl_UserReg.Find(id);
            user.IntrestedInCsharp = (user.IntrestedInCsharp == null) ? false : user.IntrestedInCsharp;
            user.IntrestedInJava = (user.IntrestedInJava == null) ? false : user.IntrestedInJava;
            user.IntrestedInPython = (user.IntrestedInPython == null) ? false : user.IntrestedInPython;
            return View(user);
        }
        [HttpPost]
        public ActionResult UserProfile(tbl_UserReg tbluser, string cSharp,string Java,string Python)
        {
            //if (cSharp == "true")
            //{
            //    tbluser.IntrestedInCsharp = true;
            //}
            //else
            //{
            //    tbluser.IntrestedInCsharp = false;
            //}
            //if (Java == "true")
            //{
            //    tbluser.IntrestedInJava = true;
            //}
            //else
            //{
            //    tbluser.IntrestedInJava = false;
            //}
            //if (Python == "true")
            //{
            //    tbluser.IntrestedInPython = true;
            //}
            //else
            //{
            //    tbluser.IntrestedInPython = false;
            //}
            //or
            tbluser.IntrestedInCsharp = (cSharp == "true") ? true : false;
            tbluser.IntrestedInJava = (Java == "true") ? true : false;
            tbluser.IntrestedInPython = (Python == "true") ? true : false;

            MVCProjectDBContext db = new MVCProjectDBContext();
            db.Entry(tbluser).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View(tbluser);
        }
    }
}