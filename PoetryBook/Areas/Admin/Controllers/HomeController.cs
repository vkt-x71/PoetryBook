using PoetryBook.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Areas.Admin.Controllers
{
    public class HomeController : baseController
    {
        // GET: Admin/Home
        public async Task<ActionResult> Index()
        {
            ExitIsNotAdmin();
            return View();
        }
    }
}