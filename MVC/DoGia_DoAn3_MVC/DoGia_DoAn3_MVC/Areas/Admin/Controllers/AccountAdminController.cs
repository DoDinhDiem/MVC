using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        // GET: Admin/AccountAdmin
        private DoGia_DoAn3Entities db = new DoGia_DoAn3Entities();
        public ActionResult LoginAdmin()
        {
            return View();
        }
        public ActionResult LoginHome()
        {
            return View();
        }
        public JsonResult getLoginAdmin(string UserName, string Pass)
        {
            try
            {
                var admin = db.QuanTris.SingleOrDefault(x => x.UserName == UserName && x.Pass == Pass);
                if (admin != null)
                {
                    Session["admin"] = admin;
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