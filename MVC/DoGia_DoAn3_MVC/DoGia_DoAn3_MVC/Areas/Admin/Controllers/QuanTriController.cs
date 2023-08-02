using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class QuanTriController : Controller
    {
        // GET: Admin/QuanTri
        QuanTriModel dbqt = new QuanTriModel();
        public ActionResult QuanTri()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return RedirectToAction("LoginHome", "AccountAdmin");
            }
            else
            {
                return View();
            }
        }
        public JsonResult getAllQT()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<QuanTri> li = dbqt.getAllQT();
                return Json(li, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get1QT(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                QuanTri qt = dbqt.get1QT(id);
                return Json(qt, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteQT(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbqt.DeleteQT(id);
                return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult createQT(QuanTri qt)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbqt.CreateQT(qt);
                return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult updateQT(QuanTri qt)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbqt.UpdateQT(qt);
                return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}