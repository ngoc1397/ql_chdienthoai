using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models.Framework;

namespace Models
{
    public class GioHangModel
    {
        private QL_WEBDTDbContext context = null;
        public GioHangModel()
        {
            context = new QL_WEBDTDbContext();
        }
        public int layIdHoaDon(int idNguoidung)
        {
            //object[] sqlParams =
            //{
            //    new SqlParameter("@idNguoidung",idNguoidung)
            //};
            //var result = context.Database.SqlQuery<int>("sp_LayIdHoaDon @idNguoidung", sqlParams).SingleOrDefault();
            //return result;
            var sql = context.HoaDons.SingleOrDefault(hd => hd.trangThai == 0 && hd.idNguoidung == idNguoidung);
            if(sql == null)
            {
                return -1;
            }
            else
            {
                int id = sql.idHoadon;
                return id;
            }
        }
        public bool themHoaDon(int idNguoidung)
        {
            object[] sqlParams =
            {
                new SqlParameter("@idNguoidung",idNguoidung)
            };
            try
            {
                context.Database.ExecuteSqlCommand("sp_ThemHoaDon @idNguoidung", sqlParams);
                return true;
            }
            catch { return false; }
        }
        public bool themGioHang(int idHoadon,int idSanpham,int soLuong)
        {
            object[] sqlParams =
            {
                new SqlParameter("@idHoadon",idHoadon),
                new SqlParameter("@idSanpham",idSanpham),
                new SqlParameter("@soLuong",soLuong)
            };
            try
            {
                context.Database.ExecuteSqlCommand("sp_ThemGioHang @idHoadon, @idSanpham, @soLuong",sqlParams);
                return true;
            }
            catch { return false; }
        }
        public void ThemVaoGioHang(int idNguoidung,int idSanpham,int soLuong)
        {
            int idHoadon = layIdHoaDon(idNguoidung);
            if(idHoadon == -1)
            {
                themHoaDon(idNguoidung);
                themGioHang(layIdHoaDon(idNguoidung), idSanpham, soLuong);
            }
            else
            {
                themGioHang(idHoadon,idSanpham,soLuong);
            }
        }
        public List<NewGioHang> LayDSGioHang(int idNguoidung)
        {
            List<NewGioHang> lst = new List<NewGioHang>();
            object[] sqlParams =
            {
                new SqlParameter("@idNguoidung",idNguoidung)
            };
            var res = context.Database.ExecuteSqlCommand("sp_XemGioHang @idNguoidung", sqlParams);
            var query = (from gh in context.GioHangs join sp in context.SanPhams on gh.idSanpham equals sp.idSanpham join hd in context.HoaDons on gh.idHoadon equals hd.idHoadon join nd in context.NguoiDungs on hd.idNguoidung equals nd.idNguoidung where nd.idNguoidung == idNguoidung && hd.trangThai == 0 select new{gh.idGiohang,sp.tenSanpham,sp.anhSanpham,sp.giaSanpham,gh.soLuong} );
            foreach(var item in query)
            {
                int idGiohang = item.idGiohang;
                string tensp = item.tenSanpham;
                int tongtien = (int)item.giaSanpham * (int)item.soLuong;
                int dongia = (int)item.giaSanpham;
                int sl = (int)item.soLuong;
                string anh = item.anhSanpham;
                NewGioHang gioHang = new NewGioHang(idGiohang,tensp,dongia,sl,tongtien,anh);
                lst.Add(gioHang);
            }
            return lst;
        }
        public void XoaGioHang(int idGioHang)
        {
            var result = context.GioHangs.SingleOrDefault(gh => gh.idGiohang == idGioHang);
            context.GioHangs.Remove(result);
            context.SaveChanges();
        }
        public bool capNhatGioHang(int idGiohang,int sl)
        {
            object[] sqlParams =
            {
                new SqlParameter("@idGioHang",idGiohang),
                new SqlParameter("@soLuong",sl)
            };
            try
            {
                context.Database.ExecuteSqlCommand("sp_CapNhatSoLuong @idGioHang, @soLuong",sqlParams);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool thanhToan(int idNguoidung)
        {
            object[] sqlParams =
            {
                new SqlParameter("@idNguoidung",idNguoidung)
            };
            try
            {
                context.Database.ExecuteSqlCommand("sp_ThanhToanHoaDon @idNguoidung",sqlParams);
                return true;
            }
            catch { return false; }
        }
    }
}
