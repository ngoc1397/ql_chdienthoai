using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models.Framework;

namespace Models
{
    public class NguoiDungModel
    {
        private QL_WEBDTDbContext context = null;
        public NguoiDungModel()
        {
            context = new QL_WEBDTDbContext();
        }
        public NguoiDung GetByUserName(string userName)
        {
            return context.NguoiDungs.SingleOrDefault(u => u.tenDangnhap == userName);
        }
        public bool Login(string username, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@tenDangnhap",username),
                new SqlParameter("@matKhau",password),
            };
            var res = context.Database.SqlQuery<bool>("sp_KiemTraDangNhap @tenDangnhap, @matKhau", sqlParams).SingleOrDefault();
            return res;
        }
        public bool CheckUserName(string username)
        {
            var result = context.NguoiDungs.Count(u => u.tenDangnhap == username);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int? KtLoaiTK(string userName)
        {
            var result = context.NguoiDungs.Single(u => u.tenDangnhap == userName);
            int? kq = result.idKieunguoidung;
            return kq;
        }
    }
}
