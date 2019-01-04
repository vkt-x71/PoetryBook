using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoetryBook.Models;
using PagedList;

namespace PoetryBook.Controllers
{
    public class CategoryController : baseController
    {
        private PoetryBookDbEntities db;
        public CategoryController()
        {
            db = new PoetryBookDbEntities();
        }
        
        public async Task<ActionResult> Index()
        {
            return View(await db.tbcategories.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<ActionResult> Details(int? id,int? page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbcategory tbcategory = await db.tbcategories.FindAsync(id);
            if (tbcategory == null)
            {
                return HttpNotFound();
            }
            int pageNumber = page ?? 1;
            ViewBag.poetrylist = tbcategory.tbpoetries.OrderByDescending(m => m.title).ToPagedList<tbpoetry>(pageNumber, 10);

            return View(tbcategory);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
