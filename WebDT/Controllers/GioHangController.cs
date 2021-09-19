using Models;
using Models.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDT.Common;

namespace WebDT.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult XemGioHang()
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "ClientLogin");
            }
            int idNguoidung = session.UserID;
            GioHangModel model = new GioHangModel();
            List<NewGioHang> lst = model.LayDSGioHang(idNguoidung);
            int sl = 0;
            int tt = 0;
            foreach (var item in lst)
            {
                sl += item.SoLuong;
                tt += item.TongTien;
            }
            ViewBag.TongSoLuong = sl;
            ViewBag.TongThanhTien = tt;
            return View(lst);
        }
        [HttpGet]
        public ActionResult ThemGioHang(int idSanpham, string URL)
        {
            GioHangModel model = new GioHangModel();
            QL_WEBDTDbContext context = new QL_WEBDTDbContext();
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("DangNhap", "ClientLogin");
            }
            else
            {
                var id = context.NguoiDungs.SingleOrDefault(nd => nd.tenDangnhap == session.UserName);
                int idKhachhang = id.idNguoidung;
                model.ThemVaoGioHang(idKhachhang, idSanpham, 1);
            }
            return Redirect(URL);
        }
        public ActionResult XoaGioHang(int idGioHang, string URL)
        {
            GioHangModel model = new GioHangModel();
            model.XoaGioHang(idGioHang);
            return Redirect(URL);
        }
        public ActionResult CapNhatGioHang(int idGiohang, FormCollection f, string URL)
        {
            int sl = int.Parse(f["txtSoLuong"].ToString());
            GioHangModel model = new GioHangModel();
            model.capNhatGioHang(idGiohang, sl);
            return Redirect(URL);
        }
        public ActionResult ThanhToanGioHang()
        {
            GioHangModel model = new GioHangModel();
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            int id = session.UserID;
            model.thanhToan(id);
            return RedirectToAction("ThongBaoThanhCong","GioHang");
        }
        public ActionResult ThongBaoThanhCong()
        {
            return View();
        }
        public ActionResult GioHangPartial()
        {
            QL_WEBDTDbContext context = new QL_WEBDTDbContext();
            int sl = 0;
            int id = 0;
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if(session == null)
            {
                sl = 0;
            }
            else if(session != null)
            {
                id = session.UserID;
                var resul = (from s in context.GioHangs join a in context.HoaDons on s.idHoadon equals a.idHoadon where a.idNguoidung == id && a.trangThai == 0 select new { s.soLuong });
                foreach (var item in resul)
                {
                    sl += (int)item.soLuong;
                }
            }
            ViewBag.SoLuong = sl;
            return View();        
        }
        public ActionResult DangNhapPartial()
        {
            QL_WEBDTDbContext context = new QL_WEBDTDbContext();
            string tenDN ="";
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                tenDN = "";
            }
            else if (session != null)
            {
                tenDN = session.DisplayName;
            }
            return View();
        }
    }
}