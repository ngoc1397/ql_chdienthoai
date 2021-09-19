namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        public int idGiohang { get; set; }

        public int? idSanpham { get; set; }

        public int? soLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? tongTien { get; set; }

        public int? idHoadon { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
