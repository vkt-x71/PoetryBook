using PoetryBook.Classes;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Controllers
{
    public class HomeController : baseController
    {
        private PoetryBookDbEntities db;
        public HomeController()
        {
            db = getDbEntities();
        }
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Install()
        {
            if(db.tbmembers.ToList().Count != 0)
            {
                Response.Redirect("/");
            }
            return View();
        }
        [HttpPost]
        public JsonResult InstallAsync(string mail,string nick, string pass, string pass2)
        {
            JsonProcess jp = null;
            try
            {
                if (pass.Length < 4 || pass.Length > 16)
                {
                    jp = new JsonProcess(false, "Şifre En Az 4, En Fazla 16 Karakter Olabilir.");
                    return Json(jp);
                }
                
                if (pass != pass2)
                {
                    jp = new JsonProcess(false, "Şifreler Birbiriyle Uyuşmuyor.");
                    return Json(jp);
                }
                if (!InOp.MailIsValid(mail))
                {
                    jp = new JsonProcess(false, "Bu Mail Adresi Geçersiz.");
                    return Json(jp);
                }
                

                tbmember member = new tbmember
                {
                    accounttype = "A",
                    mail = mail,
                    nick = nick,
                    password = InOp.CreateMD5(pass),
                    
                };
                db.tbmembers.Add(member);
                db.SaveChanges();

                Session["member"] = member;
                Session["memberid"] = member.memberID;
                jp = new JsonProcess(true, member.memberID.ToString());
                return Json(jp);

            }
            catch (DbEntityValidationException ex)
            {
                
                jp = new JsonProcess(false, "Hata Oluştu. " + ex.Message);
                return Json(jp);
            }

        }

    }
}