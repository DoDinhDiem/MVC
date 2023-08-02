using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoGia_DoAn3_MVC.Models
{
    public class NguoiDungModel
    {
        DataConnect dc = new DataConnect();
        public void CreateND(NguoiDung nd)
        {
            string sql = "Insert into NguoiDung values('" + nd.UserName + "','" + nd.Pass + "')";
            dc.thucthisql(sql);
        }
    }
}