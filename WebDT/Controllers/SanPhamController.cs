using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace WebDT.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QL_WEBDTDbContext context = new QL_WEBDTDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemChiTiet(int idSanpham)
        {
            ChiTietSanPham SanPham = context.ChiTietSanPhams.Single(sp => sp.idSanpham == idSanpham);
            return View(SanPham);
        }
        public ActionResult lay7SpSamSung()
        {
            var lstSamSung = context.SanPhams.Take(7).OrderBy(sp => sp.idHang == 1).ToList();
            return View(lstSamSung);
        }
        public ActionResult DanhSachHang()
        {
            var listHang = context.Hangs.ToList();
            return View(listHang);
        }
        public ActionResult SamSung()
        {
            var list = context.SanPhams.Where(u => u.idHang == 1).OrderBy(sp => sp.giaSanpham).ToList();
            return View(list);
        }
        public ActionResult Apple()
        {
            var list = context.SanPhams.Where(u => u.idHang == 2).OrderBy(sp => sp.giaSanpham).ToList();
            return View(list);
        }
        public ActionResult Xiaomi()
        {
            var list = context.SanPhams.Where(u => u.idHang == 3).OrderBy(sp => sp.giaSanpham).ToList();
            return View(list);
        }
        public ActionResult TimKiem(string TenSanPham)
        {
            var timKiem = context.SanPhams.Where(s => s.tenSanpham.Contains(TenSanPham)).ToList();
            return View();
        }
        public ActionResult SPTheoHang (int idHang)
        {
            var list = context.SanPhams.Where(sp => sp.idHang == idHang).ToList();
            var model = context.Hangs.Single(sp => sp.idHang == idHang);
            ViewBag.TenHang = model.tenHang;
            return View(list);
        }
    }
}