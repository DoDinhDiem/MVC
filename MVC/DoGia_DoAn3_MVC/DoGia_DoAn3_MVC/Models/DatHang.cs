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
    
    public partial class DatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatHang()
        {
            this.CTDatHangs = new HashSet<CTDatHang>();
        }
    
        public int MaDH { get; set; }
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DiaChi { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<double> TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatHang> CTDatHangs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
