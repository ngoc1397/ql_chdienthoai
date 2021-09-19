namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        public int idNguoidung { get; set; }

        public int? idKieunguoidung { get; set; }

        [StringLength(50)]
        public string hoTen { get; set; }

        [StringLength(50)]
        public string tenDangnhap { get; set; }

        [StringLength(50)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(50)]
        public string soDienthoai { get; set; }

        [StringLength(50)]
        public string eMail { get; set; }

        public virtual KieuNguoiDung KieuNguoiDung { get; set; }
    }
}
