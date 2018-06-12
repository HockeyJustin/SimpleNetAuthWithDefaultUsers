using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAdminAndUser.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOnlyController : Controller
    {
        // GET: AdminOnly
        public ActionResult Index()
        {
            return View();
        }
    }
}