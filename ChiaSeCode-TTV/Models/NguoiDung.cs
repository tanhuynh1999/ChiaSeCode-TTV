//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChiaSeCode_TTV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string TaiKhoan { get; set; }
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public string Gmail { get; set; }
        public Nullable<int> MaDemo { get; set; }
        public Nullable<int> MaDanhMuc { get; set; }
        public Nullable<int> MaPhanMucCode { get; set; }
        public Nullable<int> MaCodePay { get; set; }
    
        public virtual BanCode BanCode { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual DanhMuc DanhMuc1 { get; set; }
        public virtual Demo Demo { get; set; }
        public virtual PhanLoaiDanhMuc PhanLoaiDanhMuc { get; set; }
    }
}