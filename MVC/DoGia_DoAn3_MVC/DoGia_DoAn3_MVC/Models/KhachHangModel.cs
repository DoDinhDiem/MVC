using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class KhachHangModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<KhachHang> getAllKH()
        {
            DataTable dt = dc.getData("Select * from KhachHang");
            List<KhachHang> li = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr[0].ToString();
                kh.TenKh = dr[1].ToString();
                kh.DiaChi = dr[2].ToString();
                kh.SDT = dr[3].ToString();
                li.Add(kh);
            }
            return li;
        }
        public KhachHang get1KH(string id)
        {
            DataTable dt = dc.getData("Select * from KhachHang where MaKH='" + id.Trim() + "'");
            KhachHang kh = new KhachHang();
            kh.MaKH = dt.Rows[0][0].ToString();
            kh.TenKh = dt.Rows[0][1].ToString();
            kh.DiaChi = dt.Rows[0][2].ToString();
            kh.SDT = dt.Rows[0][3].ToString();
            return kh;
        }
        public void DeleteKH(string id)
        {
            string sql = "Delete from KhachHang where MaKH='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateKH(KhachHang kh)
        {
            string sql = "Insert into KhachHang values('',N'" + kh.TenKh + "',N'" + kh.DiaChi + "','" + kh.SDT + "')";
            dc.thucthisql(sql);
        }
        public void UpdateKH(KhachHang kh)
        {
            string sql = "Update KhachHang set TenKh=N'" + kh.TenKh + "', DiaChi=N'" + kh.DiaChi + "',SDT = '" + kh.SDT + "' where MaKH='" + kh.MaKH + "'";
            dc.thucthisql(sql);
        }
    }
}