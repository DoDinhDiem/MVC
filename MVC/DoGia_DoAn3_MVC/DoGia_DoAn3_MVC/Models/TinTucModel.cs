using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace DoGia_DoAn3_MVC.Models
{
    public class TinTucModel
    {
     
        DataConnect dc = new DataConnect();
        public List<TinTuc> getAllTT()
        {
            DataTable dt = dc.getData("Select * from TinTuc");
            List<TinTuc> li = new List<TinTuc>();
            foreach (DataRow dr in dt.Rows)
            {
                TinTuc tt = new TinTuc();
                tt.MaTT = dr[0].ToString();
                tt.TieuDe = dr[1].ToString();
                tt.NoiDung = dr[2].ToString();
                tt.NgayDang = DateTime.Parse(dr[3].ToString());
                tt.MaNV = dr[4].ToString();
                tt.Anh = dr[5].ToString();
                li.Add(tt);
            }
            return li;
        }
        public TinTuc get1TT(string id)
        {
            DataTable dt = dc.getData("Select * from TinTuc where MaTT='" + id.Trim() + "'");
            TinTuc tt = new TinTuc();
            tt.MaTT = dt.Rows[0][0].ToString();
            tt.TieuDe = dt.Rows[0][1].ToString();
            tt.NoiDung = dt.Rows[0][2].ToString();
            tt.NgayDang =dt.Rows[0][3].ToString().AsDateTime();
            tt.MaNV = dt.Rows[0][4].ToString();
            tt.Anh = dt.Rows[0][5].ToString();
            return tt;
        }
        public void DeleteTT(string id)
        {
            string sql = "Delete from TinTuc where MaTT='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateTT(TinTuc tt)
        {
            string sql = "Insert into TinTuc values('',N'" + tt.TieuDe + "',N'" + tt.NoiDung + "','" + tt.NgayDang + "', '"+ tt.MaNV + "', '"+ tt.Anh +"')";
            dc.thucthisql(sql);
        }
        public void UpdateTT(TinTuc tt)
        {
            string sql = "Update TinTuc set TieuDe=N'" + tt.TieuDe + "', NoiDung=N'" + tt.NoiDung + "',NgayDang = '" + tt.NgayDang + "',MaNV = '"+ tt.MaNV +"',Anh ='" + tt.Anh + "' where MaTT='" + tt.MaTT + "'";
            dc.thucthisql(sql);
        }
    }
}