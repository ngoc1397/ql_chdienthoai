using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDT.Common;
using System.Web.Routing;

namespace WebDT.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                (new {Controller ="CanhBao",Action="ThongBao",Area="Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}