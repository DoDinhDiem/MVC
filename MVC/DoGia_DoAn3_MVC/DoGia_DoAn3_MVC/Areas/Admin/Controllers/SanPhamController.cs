using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamModel dbsp = new SanPhamModel();
        // GET: Admin/SanPham
        public ActionResult SanPham()
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
        //Controller sản phẩm
        public JsonResult getAllSP()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<SanPham> li = dbsp.getAllSP();
                return Json(li, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get1SanPham(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                SanPham lsp = dbsp.get1SanPham(id);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteSP(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbsp.DeleteSP(id);
                return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult createSP(SanPham sp)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbsp.CreateSP(sp);
                return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UpdateSP(SanPham sp)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbsp.UpdateSP(sp);
                return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}