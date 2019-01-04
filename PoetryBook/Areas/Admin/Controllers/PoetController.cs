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
    public class PoetController : baseController
    {
        PoetryBookDbEntities db;
        public PoetController()
        {
            db = getDbEntities();
        }
        [HttpPost]
        public void AddOrEditPoetAsync(int poetid,string bio,string namesur)
        {
            string returnurl = "/Admin/Poet/Index/";

            try
            {
                
                tbpoet poet;
                if(poetid == 0)
                {
                    poet = new tbpoet()
                    {
                        biography = bio,
                        nameandsurname = namesur,

                    };
                    db.tbpoets.Add(poet);
                    db.SaveChanges();
                }
                else
                {
                    poet = db.tbpoets.Find(poetid);
                    poet.biography = bio;
                    poet.nameandsurname = namesur;
                    db.SaveChanges();
                }
                returnurl += $"/{poet.poetID}/";
                Response.Redirect(returnurl);
                
            }
            catch (Exception ex)
            {
                returnurl += $"/?error=ex";
                Response.Redirect(returnurl);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public void AddOrEditPoetryAsync(int catid,int poetidsof,int poetryid, string content, string title)
        {
            string returnurl = "/Admin/Poet/PoetryDetail/";
            
            
            try
            {

                tbpoetry poet;
                if (poetryid == 0)
                {
                    poet = new tbpoetry()
                    {
                        catidsof = catid,
                        content = content,
                        poetidsof = poetidsof,
                        title = title

                    };
                    db.tbpoetries.Add(poet);
                    db.SaveChanges();
                }
                else
                {
                    poet = db.tbpoetries.Find(poetryid);
                    poet.catidsof = catid;
                    poet.content = content;
                    poet.poetidsof = poetidsof;
                    poet.title = title;
                    db.SaveChanges();
                }
                returnurl += $"/{poet.poetidsof}/{poet.poetryID}/";
                Response.Redirect(returnurl);

            }
            catch (Exception ex)
            {
                returnurl += $"/?error=ex";
                Response.Redirect(returnurl);
            }
        }

        [HttpPost]
        public JsonResult DeletePoetAsync(int id)
        {
            ExitIsNotAdmin();
            try
            {
                db.tbpoets.Remove(db.tbpoets.FirstOrDefault(x => x.poetID == id));
                db.SaveChanges();
                return Json(new JsonProcess(true, "İşlem Başarılı"));
            }
            catch (Exception ex)
            {
                return Json(new JsonProcess(false, "Hata " + ex.Message));
            }
        }
        [HttpPost]
        public JsonResult DeletePoetryAsync(int id)
        {
            ExitIsNotAdmin();
            try
            {
                db.tbpoetries.Remove(db.tbpoetries.Find(id));
                db.SaveChanges();
                return Json(new JsonProcess(true, "İşlem Başarılı"));
            }
            catch (Exception ex)
            {
                return Json(new JsonProcess(false, "Hata " + ex.Message));
            }
        }

        // GET: Admin/Poet
        public async Task<ActionResult> Index()
        {
            
            ExitIsNotAdmin();
            ViewBag.poets = db.tbpoets.ToList();
            if (RouteData.Values["id"] != null)
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                Session.Add("poetid", id);
                return View(await db.tbpoets.FindAsync(id));
                
            }
            else
            {
                return View();
            }

        }
        public async Task<ActionResult> PoetryDetail()
        {
            ExitIsNotAdmin();
            if(RouteData.Values["id"] == null)
            {
                Response.Redirect("/Admin/");
                return View();
            }
            ViewBag.poetid = Convert.ToInt32(RouteData.Values["id"]);
            ViewBag.cats = db.tbcategories.ToList();
            if (RouteData.Values["id2"] != null)
            {
                int id = Convert.ToInt32(RouteData.Values["id2"]);
                return View(await db.tbpoetries.FindAsync(id));
            }
            else
            {
                return View();
            }
        }
    }
}