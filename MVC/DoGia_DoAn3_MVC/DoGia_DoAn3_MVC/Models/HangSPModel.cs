using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class HangSPModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<HangSP> getAllHSP()
        {
            DataTable dt = dc.getData("Select * from HangSP");
            List<HangSP> li = new List<HangSP>();
            foreach (DataRow dr in dt.Rows)
            {
                HangSP hsp = new HangSP();
                hsp.MaHang = dr[0].ToString();
                hsp.TenHang = dr[1].ToString();
                hsp.GhiChu = dr[2].ToString();

                li.Add(hsp);
            }
            return li;
        }
        public HangSP get1HSP(string id)
        {
            DataTable dt = dc.getData("Select * from HangSP where MaHang='" + id.Trim() + "'");
            HangSP hsp = new HangSP();
            hsp.MaHang = dt.Rows[0][0].ToString();
            hsp.TenHang = dt.Rows[0][1].ToString();
            hsp.GhiChu = dt.Rows[0][2].ToString();
            return hsp;
        }
        public void DeleteHSP(string id)
        {
            string sql = "Delete from HangSP where MaHang='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateHSP(HangSP hsp)
        {
            string sql = "Insert into HangSP values('',N'" + hsp.TenHang + "',N'" + hsp.GhiChu + "')";
            dc.thucthisql(sql);
        }
        public void UpdateHSP(HangSP hsp)
        {
            string sql = "Update HangSP set TenLoai=N'" + hsp.TenHang + "', GhiChu=N'" + hsp.GhiChu + "' where MaHang='" + hsp.TenHang + "'";
            dc.thucthisql(sql);
        }

       
    }
}