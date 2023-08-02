using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class NhanVienModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<NhanVien> getAllNV()
        {
            DataTable dt = dc.getData("Select * from NhanVien");
            List<NhanVien> li = new List<NhanVien>();
            foreach (DataRow dr in dt.Rows)
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = dr[0].ToString();
                nv.TenNV = dr[1].ToString();
                nv.DiaChi = dr[2].ToString();
                nv.SDT = dr[3].ToString();
                nv.Anh = dr[4].ToString();
                li.Add(nv);
            }
            return li;
        }
        public NhanVien get1NV(string id)
        {
            DataTable dt = dc.getData("Select * from NhanVien where MaNV='" + id.Trim() + "'");
            NhanVien nv = new NhanVien();
            nv.MaNV = dt.Rows[0][0].ToString();
            nv.TenNV = dt.Rows[0][1].ToString();
            nv.DiaChi = dt.Rows[0][2].ToString();
            nv.SDT = dt.Rows[0][3].ToString();
            nv.Anh = dt.Rows[0][4].ToString();
            return nv;
        }
        public void DeleteNV(string id)
        {
            string sql = "Delete from NhanVien where MaNV='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateNV(NhanVien nv)
        {
            string sql = "Insert into NhanVien values('',N'" + nv.TenNV + "',N'" + nv.DiaChi + "','" + nv.SDT + "','" + nv.Anh + "')";
            dc.thucthisql(sql);
        }
        public void UpdateNV(NhanVien nv)
        {
            string sql = "Update NhanVien set TenNV=N'" + nv.TenNV + "', DiaChi=N'" + nv.DiaChi + "',SDT = '" + nv.SDT + "', Anh = '" + nv.Anh + "' where MaNV='" + nv.MaNV + "'";
            dc.thucthisql(sql);
        }
    }
}