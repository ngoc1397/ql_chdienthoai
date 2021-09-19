using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Areas.Admin.Controllers;
using WebDT.Areas.Admin.Models;
using Models;
using Models.Framework;
using WebDT.Common;
namespace WebDT.Controllers
{
    public class ClientLoginController : Controller
    {
        // GET: ClientLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(LoginModel model)
        {
            NguoiDungModel nguoiDung = new NguoiDungModel();
            if(ModelState.IsValid)
            {
                var result = nguoiDung.Login(model.UserName,model.PassWord);
                if(result)
                {
                    var loaiTK = nguoiDung.CheckUserName(model.UserName);
                    var user = nguoiDung.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.tenDangnhap;
                    userSession.UserID = user.idNguoidung;
                    Session.Add(CommonConstant.USER_SESSION,userSession);
                    int? kq = nguoiDung.KtLoaiTK(model.UserName);
                    if(kq == 1)
                    {
                        return RedirectToAction("ThemMoiSanPham","AdSanPham", new { area = "Admin" });
                    }
                    else if(kq == 2)
                    {
                        return RedirectToAction("XemGioHang", "GioHang");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NguoiDung kh, FormCollection f)
        {
            QL_WEBDTDbContext db = new QL_WEBDTDbContext();
            var hoten = f["HoTen"];
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];
            var rematkhau = f["ReMatKhau"];
            var dienthoai = f["DienThoai"];
            var email = f["Email"];
            var diachi = f["DiaChi"];
            var tenTrung = db.NguoiDungs.Where(s => s.tenDangnhap == tendn);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được để trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Repassword không được để trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Số điện thoại không được để trống";
            }
            if (!String.IsNullOrEmpty(hoten) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && String.IsNullOrEmpty(rematkhau) == String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.idKieunguoidung = 2;
                kh.hoTen = hoten;
                kh.tenDangnhap = tendn;
                kh.matKhau = matkhau;
                kh.diaChi = diachi;
                kh.soDienthoai = dienthoai;
                kh.eMail = email;
                if (tenTrung.Count() > 0)
                {
                    ViewData["Loi6"] = "Tên đăng nhập đã được sử dụng";
                    return View();
                }
                else if(tenTrung.Count() == 0)
                {
                    db.NguoiDungs.Add(kh);
                    db.SaveChanges();
                }
                return RedirectToAction("DangNhap", "ClientLogin");
            }
            return View(kh);
        }
    }
}