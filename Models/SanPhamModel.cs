using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Framework;
using System.Data.SqlClient;
using PagedList;

namespace Models
{
    public class SanPhamModel
    {
        private QL_WEBDTDbContext context = null;
        public SanPhamModel()
        {
            context = new QL_WEBDTDbContext();
        }
        public List<SanPham> LayDSSP()
        {
            var res = context.Database.SqlQuery<SanPham>("sp_LayDanhSachSanPham").ToList();
            return res;
        }
        public bool themSanPham(int? idhang,string tenSp,string anhSP,int? giaSp)
        {
            object[] sqlParams =
            {
                new SqlParameter("@idHang",idhang),
                new SqlParameter("@tenSanpham",tenSp),
                new SqlParameter("@anhSanpham",anhSP),
                new SqlParameter("@giaSanpham",giaSp)
            };
            try
            {
                context.Database.ExecuteSqlCommand("sp_ThemSanPham @idHang,@tenSanpham,@anhSanpham,@giaSanpham", sqlParams);
                return true;
            }
            catch
            { return false; }
        }
        public bool xoaChiTietSanPham(int idSP)
        {
            try
            {
                ChiTietSanPham sp = (ChiTietSanPham)context.ChiTietSanPhams.Single(spham => spham.idSanpham == idSP);
                context.ChiTietSanPhams.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool xoaSanPham(int idsp)
        {
            try
            {
                SanPham sp = (SanPham)context.SanPhams.Single(spham => spham.idSanpham == idsp);
                context.SanPhams.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public IEnumerable<SanPham> listAllSp(string searchString,int page,int pageSize)
        {
            var id = (from sp in context.SanPhams select sp).OrderBy(sp => sp.idSanpham);
            if(!string.IsNullOrEmpty(searchString))
            {
                return id.Where(sp => sp.tenSanpham.Contains(searchString)).ToPagedList(page, pageSize);
            }
            else
            return id.ToPagedList(page,pageSize);
        }
    }
}
