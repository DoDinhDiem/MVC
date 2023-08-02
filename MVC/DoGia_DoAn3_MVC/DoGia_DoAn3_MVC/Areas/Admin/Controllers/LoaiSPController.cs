using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: Admin/LoaiSP
        LoaiSPModel dblsp = new LoaiSPModel();
        public ActionResult LoaiSanPham()
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
        public JsonResult getAllLSP()
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<LoaiSP> li = dblsp.getAllLSP();
                return Json(li, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get1LSP(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                LoaiSP lsp = dblsp.get1LSP(id);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteLSP(string id)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dblsp.DeleteLSP(id);
                return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult createLSP(LoaiSP lsp)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dblsp.CreateLSP(lsp);
                return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult updateLSP(LoaiSP lsp)
        {
            var admin = (QuanTri)Session["admin"];
            if (admin == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dblsp.UpdateLSP(lsp);
                return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}