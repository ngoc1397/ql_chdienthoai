namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [Key]
        public int idChitietsanpham { get; set; }

        public int? idSanpham { get; set; }

        [StringLength(50)]
        public string loaiManhinh { get; set; }

        [StringLength(50)]
        public string doRong { get; set; }

        [StringLength(50)]
        public string doPhangiai { get; set; }

        [StringLength(50)]
        public string cameraSau { get; set; }

        [StringLength(200)]
        public string tinhNangcamera { get; set; }

        [StringLength(50)]
        public string cameraTruoc { get; set; }

        [StringLength(50)]
        public string HDH { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string RAM { get; set; }

        [StringLength(50)]
        public string ROM { get; set; }

        [StringLength(50)]
        public string mang { get; set; }

        [StringLength(50)]
        public string sim { get; set; }

        [StringLength(50)]
        public string wifi { get; set; }

        [StringLength(50)]
        public string bluetooth { get; set; }

        [StringLength(50)]
        public string dungLuongpin { get; set; }

        [StringLength(50)]
        public string kichThuoc { get; set; }

        [StringLength(50)]
        public string trongLuong { get; set; }

        public string mota { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
