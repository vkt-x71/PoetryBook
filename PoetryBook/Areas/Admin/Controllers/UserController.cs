using PoetryBook.Controllers;
using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Areas.Admin.Controllers
{
    public class UserController : baseController
    {
        PoetryBookDbEntities db;
        public UserController()
        {
            db = getDbEntities();
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return View(db.tbmembers.ToList());
        }
        
        public void ChangeType(int id)
        {
            tbmember user = db.tbmembers.Find(id);
            if (user.accounttype == "A")
                user.accounttype = "N";
            else
                user.accounttype = "A";
            db.SaveChanges();
            Response.Redirect("/Admin/User");
        }
        public void Delete(int id)
        {
            tbmember user = db.tbmembers.Find(id);
            if (user.accounttype.ToLower() == "A")
            {
                Response.Redirect("/Admin/User");
                return;
            }
            db.tbmembers.Remove(user);
            db.SaveChanges();
            Response.Redirect("/Admin/User");
        }
    }
}