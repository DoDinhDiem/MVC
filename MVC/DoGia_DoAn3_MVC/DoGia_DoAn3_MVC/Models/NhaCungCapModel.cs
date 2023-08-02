using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class NhaCungCapModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<NhaCungCap> getAllNCC()
        {
            DataTable dt = dc.getData("Select * from NhaCungCap");
            List<NhaCungCap> li = new List<NhaCungCap>();
            foreach (DataRow dr in dt.Rows)
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = dr[0].ToString();
                ncc.TenNCC = dr[1].ToString();
                ncc.DiaChi = dr[2].ToString();
                ncc.SDT = dr[3].ToString();
                li.Add(ncc);
            }
            return li;
        }
        public NhaCungCap get1NCC(string id)
        {
            DataTable dt = dc.getData("Select * from NhaCungCap where MaNCC='" + id.Trim() + "'");
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = dt.Rows[0][0].ToString();
            ncc.TenNCC = dt.Rows[0][1].ToString();
            ncc.DiaChi = dt.Rows[0][2].ToString();
            ncc.SDT = dt.Rows[0][3].ToString();
            return ncc;
        }
        public void DeleteNCC(string id)
        {
            string sql = "Delete from NhaCungCap where MaNCC='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateNCC(NhaCungCap ncc)
        {
            string sql = "Insert into NhaCungCap values('',N'" + ncc.TenNCC + "',N'" + ncc.DiaChi + "','" + ncc.SDT + "')";
            dc.thucthisql(sql);
        }
        public void UpdateNCC(NhaCungCap ncc)
        {
            string sql = "Update NhaCungCap set TenNCC=N'" + ncc.TenNCC + "', DiaChi=N'" + ncc.DiaChi + "',SDT='" + ncc.SDT + "' where MaNCC='" + ncc.MaNCC + "'";
            dc.thucthisql(sql);
        }
    }
}
