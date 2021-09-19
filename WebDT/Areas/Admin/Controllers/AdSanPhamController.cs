using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;
using System.Data.Entity;
namespace WebDT.Areas.Admin.Controllers
{
    public class AdSanPhamController : BaseController
    {
        // GET: Admin/AdSanPham
        QL_WEBDTDbContext context = new QL_WEBDTDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HangPartial()
        {
            var ListHang = context.Hangs.ToList();
            return View(ListHang);
        }
        [HttpGet]
        public ActionResult ThemMoiSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var model = new SanPhamModel();
                if (model.themSanPham(sp.idHang, sp.tenSanpham, sp.anhSanpham, sp.giaSanpham))
                {

                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(sp);
        }
        public ActionResult ShowSanPham(string searchString,int page = 1,int pageSize = 12)
        {
            var dao = new SanPhamModel();
            var model = dao.listAllSp(searchString,page,pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemChiTietSanPham(int idSanPham)
        {
            ViewBag.iSanpham = idSanPham;
            var result = context.ChiTietSanPhams.SingleOrDefault(sp => sp.idSanpham == idSanPham);
            if(result != null)
            {
                Response.Write("<script>alert('Chi tiết sản phẩm đã tồn tại');</script>");
                return RedirectToAction("ShowSanPham","AdSanPham");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ThemChiTietSanPham(ChiTietSanPham chiTietSP)
        {
            if (ModelState.IsValid)
            {
                context.ChiTietSanPhams.Add(chiTietSP);
                context.SaveChanges();
            }
            return View(chiTietSP);
        }
        [HttpGet]
        public ActionResult ThemHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemHang(Hang hang)
        {
            if (ModelState.IsValid)
            {
                context.Hangs.Add(hang);
                context.SaveChanges();
            }
            return View(hang);
        }
        public ActionResult XoaSanPham(int idSanpham,string URL)
        {
            SanPhamModel adsanPham = new SanPhamModel();
            if(ModelState.IsValid)
            {
                if(adsanPham.xoaChiTietSanPham(idSanpham))
                {
                    adsanPham.xoaSanPham(idSanpham);
                }
            }
            else
            {
                ModelState.AddModelError("","Xóa không thành công");
            }
            return Redirect(URL);
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult CapNhatCTSanPham(int idSanPham)
        {
            ViewBag.iSanpham = idSanPham;
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatCTSanPham(ChiTietSanPham chiTietSP)
        {
            if (ModelState.IsValid)
            {
                context.ChiTietSanPhams.Attach(chiTietSP);
                context.Entry(chiTietSP).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ShowSanPham","AdSanPham");
            }
            return View(chiTietSP);
        }
    }
}