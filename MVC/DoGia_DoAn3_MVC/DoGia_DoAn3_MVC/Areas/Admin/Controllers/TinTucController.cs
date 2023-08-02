using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Admin/TinTuc

        TinTucModel dbtt = new TinTucModel();
        public ActionResult TinTuc()
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
        public JsonResult getAllTT()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<TinTuc> li = dbtt.getAllTT();
                return Json(li, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get1TT(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TinTuc tt = dbtt.get1TT(id);
                return Json(tt, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteTT(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbtt.DeleteTT(id);
                return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult createTT(TinTuc tt)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbtt.CreateTT(tt);
                return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult updateHSP(TinTuc tt)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbtt.UpdateTT(tt);
                return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}