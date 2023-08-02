using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        NguoiDungModel dbnd = new NguoiDungModel();
        private DoGia_DoAn3Entities db = new DoGia_DoAn3Entities();
        public ActionResult LoginCustumer()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ViewResult LoginHome()
        {
            return View();
        }
        public ViewResult LoginOut()
        {
            return View();
        }
        public JsonResult createND(NguoiDung nd)
        {
            dbnd.CreateND(nd);
            return Json(new { success = "Đăng ký thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getLoginCustumer(string UserName, string Pass)
        {
            try
            {
                var user = db.NguoiDungs.SingleOrDefault(x => x.UserName == UserName && x.Pass == Pass);
                if (user != null)
                {
                    Session["user"] = user;
                }
                return Json(new { ok = 1 }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { ok = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}