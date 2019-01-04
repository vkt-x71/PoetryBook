using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoetryBook.Controllers
{
    public class baseController : Controller
    {
        private PoetryBookDbEntities db;
        
        protected PoetryBookDbEntities getDbEntities()
        {
            if (db == null) return new PoetryBookDbEntities();
            else return db;
        }
        protected void ExitIsNotAdmin()
        {
            tbmember member = Session["member"] as tbmember;
            if (member == null)
                Response.Redirect("/");
            else if (member.accounttype != "A")
                Response.Redirect("/");

        }

        
    }
}