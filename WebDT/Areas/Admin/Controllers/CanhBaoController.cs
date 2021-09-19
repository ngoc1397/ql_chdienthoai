using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    public class CanhBaoController : Controller
    {
        // GET: Admin/CanhBao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongBao()
        {
            return View();
        }
    }
}