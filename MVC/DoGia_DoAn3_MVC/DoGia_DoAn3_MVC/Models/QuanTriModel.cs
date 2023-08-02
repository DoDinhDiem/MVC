using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class QuanTriModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả tài khoản quản trị
        public List<QuanTri> getAllQT()
        {
            DataTable dt = dc.getData("Select * from QuanTri");
            List<QuanTri> li = new List<QuanTri>();
            foreach (DataRow dr in dt.Rows)
            {
                QuanTri qt = new QuanTri();
                qt.UserName = dr[0].ToString();
                qt.Pass = dr[1].ToString();
                li.Add(qt);
            }
            return li;
        }
        public QuanTri get1QT(string id)
        {
            DataTable dt = dc.getData("Select * from QuanTri where UserName='" + id.Trim() + "'");
            QuanTri qt = new QuanTri();
            qt.UserName = dt.Rows[0][0].ToString();
            qt.Pass = dt.Rows[0][1].ToString();
            return qt;
        }
        public void DeleteQT(string id)
        {
            string sql = "Delete from QuanTri where UserName='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void CreateQT(QuanTri qt)
        {
            string sql = "Insert into QuanTri values('" + qt.UserName + "','" + qt.Pass + "')";
            dc.thucthisql(sql);
        }
        public void UpdateQT(QuanTri qt)
        {
            string sql = "Update QuanTri set Pass='" + qt.Pass + "' where UserName='" + qt.UserName + "'";
            dc.thucthisql(sql);
        }
    }
}