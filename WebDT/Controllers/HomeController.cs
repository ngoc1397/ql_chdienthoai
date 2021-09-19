using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace WebDT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var result = new SanPhamModel().LayDSSP();
            return View(result);
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}