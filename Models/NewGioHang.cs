using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class NewGioHang
    {
        int idGioHang;
        string tenSP;
        int soLuong;
        int donGia;
        int tongTien;
        int idHoadon;
        string anh;

        public int IdGioHang { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int TongTien { get; set; }
        public int IdHoadon { get; set; }
        public int DonGia { get; set; }
        public string Anh { get; set; }

        public NewGioHang()
        {

        }
        public NewGioHang(int idGioHang,string tenSP,int donGia,int soLuong,int tongTien,string anh)
        {
            this.IdGioHang = idGioHang;
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.TongTien = tongTien;
            this.DonGia = donGia;
            this.Anh = anh;
        }
    }
}
