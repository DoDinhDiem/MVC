using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        NhanVienModel dbnv = new NhanVienModel();
        public ActionResult NhanVien()
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
        //Controller loại sản phẩm
        public JsonResult getAllNV()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<NhanVien> li = dbnv.getAllNV();
                return Json(li, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get1NV(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                NhanVien NV = dbnv.get1NV(id);
                return Json(NV, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteNV(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbnv.DeleteNV(id);
                return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult createNV(NhanVien NV)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbnv.CreateNV(NV);
                return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult updateNV(NhanVien NV)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dbnv.UpdateNV(NV);
                return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}