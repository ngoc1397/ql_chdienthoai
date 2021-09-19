using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace WebDT.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        QL_WEBDTDbContext context = new QL_WEBDTDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoaiTinPartial()
        {
            var model = context.LoaiTins.ToList();
            return View(model);
        }
        public ActionResult TinTucTheoLoaiTin(int idLoaiTin)
        {
            var list = context.TinTucs.Where(sp => sp.idLoaitin == idLoaiTin).ToList();
            var model = context.LoaiTins.Single(sp => sp.idLoaitin == idLoaiTin);
            ViewBag.TenHang = model.tenLoaitin;
            return View(list);
        }
        public ActionResult XemChiTietTin(int idTin)
        {
            TinTuc tt = context.TinTucs.Single(sp => sp.idTin == idTin);
            return View(tt);
        }
    }
}