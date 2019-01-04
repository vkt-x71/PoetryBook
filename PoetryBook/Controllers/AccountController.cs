using PoetryBook.Classes;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Controllers
{
    public class AccountController : baseController
    {
        private PoetryBookDbEntities db;
        public AccountController()
        {
            db = getDbEntities();
        }
        // GET: Account
        public ActionResult Create()
        {
            if (Session["member"] != null)
                Response.Redirect("/");
            return View();
        }
        [HttpPost]
        public JsonResult CreateAsync(string nick,string mail,string namesur,string pass,string pass2,string sec,string dtS,string gender)
        {
                        
            JsonProcess jp = null;
            DateTime dt = Convert.ToDateTime(dtS);
            try
            {
                
                if (pass.Length < 4 || pass.Length > 16)
                {
                    jp = new JsonProcess(false, "Şifre En Az 4, En Fazla 16 Karakter Olabilir.");
                    return Json(jp);
                }
                if (Session["resim"] == null)
                {
                    jp = new JsonProcess(false, "Bir Sorun Oluştu.");
                    return Json(jp);
                }
                if (Session["resim"].ToString() != sec)
                {
                    jp = new JsonProcess(false, "Güvenlik Kodu Hatalı");
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
                if (db.tbmembers.FirstOrDefault(x => x.mail == mail) != null)
                {
                    jp = new JsonProcess(false, "Bu Mail Adresi Kullanılıyor.");
                    return Json(jp);
                }
                if (db.tbmembers.FirstOrDefault(x => x.nick == nick) != null)
                {
                    jp = new JsonProcess(false, "Bu Kullanıcı Adı Kullanılıyor.");
                    return Json(jp);
                }

                tbmember member = new tbmember()
                {
                    accounttype = "N",
                    birthdate = dt,
                    gender = gender,
                    mail = mail,
                    nameandsurname = namesur,
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
            catch (Exception ex)
            {
                jp = new JsonProcess(false, "Hata Oluştu. " + ex.Message);
                return Json(jp);
            }

        }

        // GET: Account
        public ActionResult Login()
        {
            if (Session["member"] != null)
                Response.Redirect("/");
            return View();
        }
        [HttpPost]
        public JsonResult LoginAsync(string mail,string pass,string remember)
        {
            try
            {
                if (string.IsNullOrEmpty(mail))
                    return Json(new JsonProcess(false, "Kullanıcı Adı Boş"));
                if (string.IsNullOrEmpty(pass))
                    return Json(new JsonProcess(false, "Şifre Boş"));

                pass = InOp.CreateMD5(pass);
                tbmember member = db.tbmembers.FirstOrDefault(x => (x.mail == mail || x.nick == mail) && x.password == pass);
                if (member == null)
                {
                    return Json(new JsonProcess(false, "Yanlış Kullanıcı Adı Ve Şifre"));
                }

                
                Session["member"] = member;
                Session["memberid"] = member.memberID;
                if (remember == "true")
                {
                    HttpCookie kuki = new HttpCookie("vktpbcook", mail);
                    //cookie'nin ne kadar geçerlilik süresi olacağını belirledik
                    kuki.Expires = DateTime.Now.AddDays(30);
                    //oluşturduğumuz cookie'i client'a ekledik
                    Response.Cookies.Add(kuki);
                }
                return Json(new JsonProcess(true, ""));
            }
            catch (Exception ex)
            {
                return Json(new JsonProcess(false, "Hata " + ex.Message));
            }

        }
        [HttpGet]
        public void LogOut()
        {
            if (Request.Cookies["vktpbcook"] != null) // Cookie var mı?
            {
                // myCookie isimli nesnemizi oluşturalım.
                HttpCookie myCookie = new HttpCookie("vktpbcook");
                // Geçerlilik süresine -1 gün ekleyip, geçmişe alalım.
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                // Ve Cookie mizi yeniden gönderelim.
                Response.Cookies.Add(myCookie);
            }
            Session.Abandon();
            Response.Redirect("/");
        }


    }
}