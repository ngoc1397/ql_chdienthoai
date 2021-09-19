using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using WebDT.Common;
using WebDT.Areas.Admin.Code;
using WebDT.Areas.Admin.Models;

namespace WebDT.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            NguoiDungModel daoNguoiDung = new NguoiDungModel();
            if(ModelState.IsValid)
            {
                var result = daoNguoiDung.Login(model.UserName, model.PassWord);
                if(result)
                {
                    var user = daoNguoiDung.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.tenDangnhap;
                    userSession.UserID = user.idNguoidung;
                    userSession.DisplayName = user.hoTen;
                    Session.Add(CommonConstant.USER_SESSION,userSession);
                    return RedirectToAction("ThemMoiSanPham", "AdSanPham", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View(model);
        }
    }
}