using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        SanPhamModel dbsp = new SanPhamModel();
        public ActionResult XemGioHang()
        {

            return View();
        }
        public ActionResult ThanhToan()
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
        //viết hàm mua hàng
        public JsonResult MuaHang(string id)
        {
            //biến session
            //Nếu giỏ hàng rỗng -->thêm vào giỏ hàng, số lượng 1
            //nếu giỏ hàng k rỗng --> sp chưa có --> thêm, sp đã có -->cộng số lượng thêm 1
            //cứ làm xong bất kỳ thao tác nào thì luôn lưu lại trong session


            //Nếu chưa có sản phẩm trong giỏ hàng
            List<GioHang> gh = null;
            int tongtien = 0;
            int soluong = 0;
            if (Session["giohang"] == null)
            {
                //thêm
                GioHang a = new GioHang();
                var sp = dbsp.get1SanPham(id);
                a.ID = sp.MaSP;
                a.Ten = sp.TenSP;
                a.Anh = sp.Anh;
                a.SL = 1;
                a.Gia = (int)sp.DonGia;
                //thêm vào list
                gh = new List<GioHang>();
                gh.Add(a);
                Session["giohang"] = gh;
            }
            else
            {
                gh = (List<GioHang>)Session["giohang"];
                //khai báo biến lưu trữ sp đang có trong gio hang
                var test = gh.Find(s => s.ID == id);
                if (test == null)
                {
                    GioHang a = new GioHang();
                    var sp = dbsp.get1SanPham(id);
                    a.ID = sp.MaSP;
                    a.Ten = sp.TenSP;
                    a.Anh = sp.Anh;
                    a.SL = 1;
                    a.Gia = (int)sp.DonGia;
                    gh.Add(a);
                }
                else
                {
                    test.SL = int.Parse(test.SL.ToString()) + 1;
                }
                Session["giohang"] = gh;
                foreach (GioHang x in gh)
                {
                    tongtien += x.SL * x.Gia;
                    soluong += x.SL;
                }
            }
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadGioHang()
        {
            List<GioHang> gh = new List<GioHang>();
            int tongtien = 0;
            int soluong = 0;
            if (Session["giohang"] != null)
            {
                gh = (List<GioHang>)Session["giohang"];
            }
            foreach (GioHang a in gh)
            {
                tongtien += a.SL * a.Gia;
                soluong += a.SL;
            }
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Tang1SP(string id)
        {
            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            if (test != null)
            {
                test.SL = int.Parse(test.SL.ToString()) + 1;
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Giam1SP(string id)
        {

            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            int sl = int.Parse(test.SL.ToString());
            if (sl > 1)
            {
                test.SL = sl - 1;
            }
            else
            {
                gh.Remove(test);
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Xoa1SP(string id)
        {
            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            if (test != null)
            {
                gh.Remove(test);
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}