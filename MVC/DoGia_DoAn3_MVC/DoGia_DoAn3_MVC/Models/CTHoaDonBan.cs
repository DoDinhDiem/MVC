//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoGia_DoAn3_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> GiamGia { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    
        public virtual HoaDonBan HoaDonBan { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
