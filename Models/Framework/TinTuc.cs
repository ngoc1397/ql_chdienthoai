namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int idTin { get; set; }

        public int? idLoaitin { get; set; }

        public string tieuDe { get; set; }

        [StringLength(100)]
        public string anhBia { get; set; }

        public string noiDung { get; set; }

        public virtual LoaiTin LoaiTin { get; set; }
    }
}
