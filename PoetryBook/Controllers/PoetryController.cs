using PagedList;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Controllers
{
    public class PoetryController : baseController
    {
        PoetryBookDbEntities db;
        public PoetryController()
        {
            db = getDbEntities();
        }
        // GET: Poetry
        public async Task<ActionResult> Index(int id)
        {
            return View(await db.tbpoetries.FindAsync(id));
        }

        public async Task<ActionResult> Search(int? page)
        {
            if (Request.QueryString["q"] == null)
            {
                Response.Redirect("/");
                return View();
            }
            string word = Request.QueryString["q"];
            int pageNumber = page ?? 1;
            IPagedList<tbpoetry> data = db.tbpoetries.Where(x => x.content.Contains(word) || x.title.Contains(word)).OrderBy(x => x.title).ToPagedList(pageNumber, 10);
            return View(data);
        }
    }
}