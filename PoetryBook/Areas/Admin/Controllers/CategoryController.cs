using PoetryBook.Classes;
using PoetryBook.Controllers;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Areas.Admin.Controllers
{
    public class CategoryController : baseController
    {

        PoetryBookDbEntities db;
        public CategoryController()
        {
            db = getDbEntities();
        }
        [HttpPost]
        public void AddCategoryAsync(int catid,string name, string desc)
        {
            ExitIsNotAdmin();
            string returnUrl = "/Admin/Category/Index/";

            try
            {

                tbcategory cat = null;
                if (catid != 0)
                {
                    cat = db.tbcategories.FirstOrDefault(x => x.categoryID == catid);
                    cat.name = name;
                    cat.description = desc;
                    db.SaveChanges();

                }
                else
                {
                    cat = new tbcategory()
                    {
                        name = name,
                        description = desc

                    };
                    db.tbcategories.Add(cat);
                    db.SaveChanges();
                    
                }

                returnUrl += cat.categoryID.ToString() + "/";


                Response.Redirect(returnUrl);
            }
            catch (Exception ex)
            {
                Response.Redirect(returnUrl + "?error=ex");
            }
        }

        [HttpPost]
        public JsonResult DeleteCatAsync(int catid)
        {
            ExitIsNotAdmin();
            try
            {
                db.tbcategories.Remove(db.tbcategories.FirstOrDefault(x => x.categoryID == catid));
                db.SaveChanges();
                return Json(new JsonProcess(true, "İşlem Başarılı"));
            }
            catch (Exception ex)
            {
                return Json(new JsonProcess(false, "Hata " + ex.Message));
            }
        }

        
        public async Task<ActionResult> Index()
        {
            ExitIsNotAdmin();
            ViewBag.cats = db.tbcategories.ToList();
            if (RouteData.Values["id"] != null)
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                return View(await db.tbcategories.FindAsync(id));
            }
            else
            {
                return View();
            }
        }
        

    }
}