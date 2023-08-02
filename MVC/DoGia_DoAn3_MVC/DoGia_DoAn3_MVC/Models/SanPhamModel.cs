using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class SanPhamModel
    {
        DataConnect dc = new DataConnect();
        //Viết hàm lấy tất cả sản phẩm
        public List<SanPham> getAllSP()
        {
            DataTable dt = dc.getData("Select * from SanPham");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.Ram = dr[3].ToString();
                sp.Rom = dr[4].ToString();
                sp.SoLuong = int.Parse(dr[5].ToString());
                sp.DonGia = int.Parse(dr[6].ToString());
                sp.MaLoai = dr[7].ToString();
                sp.MaHang = dr[8].ToString();
                sp.Anh = dr[9].ToString();
                li.Add(sp);
            }
            return li;
        }
        public SanPham get1SanPham(string ma)
        {
            SanPham sp = new SanPham();
            DataTable dt = dc.getData("Select * from SanPham where MaSP='" + ma.Trim() + "'");
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.TenSP = dt.Rows[0][1].ToString();
            sp.MoTa = dt.Rows[0][2].ToString();
            sp.Ram = dt.Rows[0][3].ToString();
            sp.Rom = dt.Rows[0][4].ToString();
            sp.SoLuong = int.Parse(dt.Rows[0][5].ToString());
            sp.DonGia = int.Parse(dt.Rows[0][6].ToString());
            sp.MaLoai = dt.Rows[0][7].ToString();
            sp.MaHang = dt.Rows[0][8].ToString();
            sp.Anh = dt.Rows[0][9].ToString();
            return sp;
        }
        public List<SanPham> getSPbyLSP(string id)
        {
            DataTable dt = dc.getData("select * from SanPham where MaLoai='" + id.Trim() + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.Ram = dr[3].ToString();
                sp.Rom = dr[4].ToString();
                sp.SoLuong = int.Parse(dr[5].ToString());
                sp.DonGia = int.Parse(dr[6].ToString());
                sp.MaLoai = dr[7].ToString();
                sp.MaHang = dr[8].ToString();
                sp.Anh = dr[9].ToString();
                li.Add(sp);
            }
            return li;
        }
        public void CreateSP(SanPham sp)
        {
            string sql = "insert into SanPham values('',N'" + sp.TenSP + "',N'" + sp.MoTa + "','" + sp.Ram + "','" + sp.Rom + "','" + sp.SoLuong + "','" + sp.DonGia + "','" + sp.MaLoai + "','" + sp.MaHang + "','" + sp.Anh + "')";
            dc.thucthisql(sql);
        }
        public void DeleteSP(string id)
        {
            string sql = "delete from SanPham where MaSP='" + id + "'";
            dc.thucthisql(sql);
        }
        public void UpdateSP(SanPham sp)
        {
            string sql = "Update SanPham set TenSP=N'" + sp.TenSP + "',MoTa=N'" + sp.MoTa + "',Ram='" + sp.Ram + "',Rom='" + sp.Rom + "', SoLuong='" + sp.SoLuong + "', DonGia='" + sp.DonGia + "', MaLoai='" + sp.MaLoai + "', MaHang='" + sp.MaHang + "', Anh='" + sp.Anh + "' where MaSP='" + sp.MaSP + "'";
            dc.thucthisql(sql);
        }
    }
}