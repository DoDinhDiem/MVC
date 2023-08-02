using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class LoaiSPModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<LoaiSP> getAllLSP()
        {
            DataTable dt = dc.getData("Select * from LoaiSP");
            List<LoaiSP> li = new List<LoaiSP>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP lsp = new LoaiSP();
                lsp.MaLoai = dr[0].ToString();
                lsp.TenLoai = dr[1].ToString();
                lsp.GhiChu = dr[2].ToString();

                li.Add(lsp);
            }
            return li;
        }
        public LoaiSP get1LSP(string id)
        {
            DataTable dt = dc.getData("Select * from LoaiSP where MaLoai='" + id.Trim() + "'");
            LoaiSP lsp = new LoaiSP();
            lsp.MaLoai = dt.Rows[0][0].ToString();
            lsp.TenLoai = dt.Rows[0][1].ToString();
            lsp.GhiChu = dt.Rows[0][2].ToString();
            return lsp;
        }
        public void DeleteLSP(string id)
        {
            string sql = "Delete from LoaiSP where MaLoai='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateLSP(LoaiSP lsp)
        {
            string sql = "Insert into LoaiSP values('',N'" + lsp.TenLoai + "',N'" + lsp.GhiChu + "')";
            dc.thucthisql(sql);
        }
        public void UpdateLSP(LoaiSP lsp)
        {
            string sql = "Update LoaiSP set TenLoai=N'" + lsp.TenLoai + "', GhiChu=N'" + lsp.GhiChu + "' where MaLoai='" + lsp.MaLoai + "'";
            dc.thucthisql(sql);
        }
    }
}