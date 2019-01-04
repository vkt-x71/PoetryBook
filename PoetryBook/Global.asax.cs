using PoetryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PoetryBook
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Areas.Admin.AdminAreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        
        }
        protected void Session_Start()
        {
            PoetryBookDbEntities db = new PoetryBookDbEntities();
            if (db.tbmembers.ToList() == null || db.tbmembers.ToList().Count == 0)
            {
                Response.Redirect("/Home/Install/");
                return;
            }
            
            if (Session["memberid"] == null)
            {
                if (Request.Cookies["vktpbcook"] != null)
                {// beni hatırla aktifse cookide değer vardır
                    // giriş işlemleri ve session işlemleri yapılır.
                    string name = Request.Cookies["vktpbcook"].Value;
                    tbmember usr = db.tbmembers.FirstOrDefault(x => x.mail == name || x.nick == name);
                    if (usr != null)
                    {// eğer böyle bir kayıt varsa kontrollere başlıyoruz.
                        Session["member"] = usr;
                        Session["memberid"] = usr.memberID;

                    }
                }
            }
        }
    }
}
