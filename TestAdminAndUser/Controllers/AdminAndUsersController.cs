using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAdminAndUser.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class AdminAndUsersController : Controller
    {
        // GET: AdminAndUsers
        public ActionResult Index()
        {
            return View();
        }
    }
}