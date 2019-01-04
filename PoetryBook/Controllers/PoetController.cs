using PagedList;
using PagedList.Mvc;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Controllers
{
    public class PoetController : baseController
    {
        PoetryBookDbEntities db;
        public PoetController()
        {
            db = getDbEntities();
        }
        public async Task<ActionResult> Details(int? id, int? page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbpoet poets = await db.tbpoets.FindAsync(id);
            if (poets == null)
            {
                return HttpNotFound();
            }
            int pageNumber = page ?? 1;
            ViewBag.poetrylist = poets.tbpoetries.OrderByDescending(m => m.title).ToPagedList<tbpoetry>(pageNumber, 10);

            return View(poets);
        }


        public async Task<ActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            IPagedList<tbpoet> data = db.tbpoets.OrderByDescending(m => m.nameandsurname)
                            .ToPagedList<tbpoet>(pageNumber, 10);
            return View(data);
        }
    }
}