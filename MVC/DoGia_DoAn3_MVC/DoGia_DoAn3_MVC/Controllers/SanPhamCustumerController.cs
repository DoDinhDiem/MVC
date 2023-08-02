using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DoGia_DoAn3_MVC.Controllers
{
    public class SanPhamCustumerController : Controller
    {
        // GET: SanPhamCustumer
        private DoGia_DoAn3Entities db = new DoGia_DoAn3Entities();
        LoaiSPModel dblsp = new LoaiSPModel();
        SanPhamModel dbsp = new SanPhamModel();
        TinTucModel dbtt= new TinTucModel();
        public ActionResult SanPham()
        {
            var user = (NguoiDung)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LoginHome", "Account");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ChiTiet(string id)
        {
            ViewBag.MaSP = id;
            var user = (NguoiDung)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LoginHome", "Account");
            }
            else
            {
                return View();
            }
        }
        public ActionResult DanhMuc(string id)
        {
            ViewBag.MaLoai = id;
            var user = (NguoiDung)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LoginHome", "Account");
            }
            else
            {
                return View();
            }
        }
        public ActionResult TinTuc()
        {
            var user = (NguoiDung)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LoginHome", "Account");
            }
            else
            {
                return View();
            }
        }
        public JsonResult get1SanPham(string id)
        {
            SanPham sp = dbsp.get1SanPham(id);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllLSP()
        {
            List<LoaiSP> li = dblsp.getAllLSP();
            li.ForEach(lsp =>
            {
                List<SanPham> lstSP = dbsp.getSPbyLSP(lsp.MaLoai).ToList();
                lsp.ListSanPham = lstSP;
            });

            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getSPbyLoai(string id)
        {
            LoaiSP lsp = dblsp.get1LSP(id);
            List<SanPham> lstSP = dbsp.getSPbyLSP(id).ToList();
            lsp.ListSanPham = lstSP;
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getTenLoai(string id)
        {
            LoaiSP lsp = dblsp.get1LSP(id);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllSP()
        {
            List<SanPham> li = dbsp.getAllSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllTT()
        {
            List<TinTuc> li = dbtt.getAllTT();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
    }
}