using DoGia_DoAn3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGia_DoAn3_MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Home()
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
    }
}