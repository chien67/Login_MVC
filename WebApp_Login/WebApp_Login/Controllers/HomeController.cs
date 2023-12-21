using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp_Login.Models;

namespace WebApp_Login.Controllers
{
    public class HomeController : Controller
    {
        LoginModel db = new LoginModel();
        public ActionResult Index()
        {
            return View();
        }

        //HttpGet /Home/Register
        public ActionResult Register()
        {
            return View();
        }

        //Http Post /Home/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        //HttpGet /Home/Login
        public ActionResult Login()
        {
            return View();
        }

        //Http Post /Home/Register
        [HttpPost]
        public ActionResult Login(User user)
        {
            var taikhoanForm = user.TaiKhoan;
            var matkhauForm = user.MatKhau;
            var userCheck = db.Users.SingleOrDefault(x=>x.TaiKhoan.Equals(taikhoanForm) && x.MatKhau.Equals(matkhauForm));
            if(userCheck != null)
            {
                Session["User"]= userCheck;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, Vui lòng thử lại";
                return View("Login");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}