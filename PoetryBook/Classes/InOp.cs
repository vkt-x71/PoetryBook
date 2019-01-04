using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PoetryBook.Classes
{
    public enum UILang
    {
        English,
        Turkish,
    }

    public class InOp
    {
        public static UILang getUiLang()
        {
            if (HttpContext.Current.Request.Cookies["vktuilang"] == null)
            {
                return UILang.Turkish;
            }
            if (HttpContext.Current.Request.Cookies["vktuilang"].Value == "tr")
                return UILang.Turkish;
            if (HttpContext.Current.Request.Cookies["vktuilang"].Value == "eng")
                return UILang.English;
            return UILang.Turkish;
        }
        public static string getUILangTextFor(string name)
        {
            if (getUiLang() == UILang.Turkish)
                return getUiLangTrTextFor(name);
            else
                return getUiLangEnTextFor(name);
        }

        private static string getUiLangEnTextFor(string name)
        {
            if (name == "strAbout")
                return Content.lang.eng.strAbout;
            if (name == "strAdminPanel")
                return Content.lang.eng.strAdminPanel;
            if (name == "strAlreadyAccount")
                return Content.lang.eng.strAlreadyAccount;
            if (name == "strBirthDate")
                return Content.lang.eng.strBirthDate;
            if (name == "strCategories")
                return Content.lang.eng.strCategories;
            if (name == "strCategory")
                return Content.lang.eng.strCategory;
            if (name == "strCategoryManagement")
                return Content.lang.eng.strCategoryManagement;
            if (name == "strComplete")
                return Content.lang.eng.strComplete;
            if (name == "strConfirm")
                return Content.lang.eng.strConfirm;
            if (name == "strContact")
                return Content.lang.eng.strContact;
            if (name == "strCreateAcc")
                return Content.lang.eng.strCreateAcc;
            if (name == "strCreateAccount")
                return Content.lang.eng.strCreateAccount;
            if (name == "strDeleteUser")
                return Content.lang.eng.strDeleteUser;
            if (name == "strFemale")
                return Content.lang.eng.strFemale;
            if (name == "strGender")
                return Content.lang.eng.strGender;
            if (name == "strHome")
                return Content.lang.eng.strHome;
            if (name == "strInstall")
                return Content.lang.eng.strInstall;
            if (name == "strLangText")
                return Content.lang.eng.strLangText;
            if (name == "strLogin")
                return Content.lang.eng.strLogin;
            if (name == "strLogOut")
                return Content.lang.eng.strLogOut;
            if (name == "strMail")
                return Content.lang.eng.strMail;
            if (name == "strMakeAdmin")
                return Content.lang.eng.strMakeAdmin;
            if (name == "strMakeNormal")
                return Content.lang.eng.strMakeNormal;
            if (name == "strMale")
                return Content.lang.eng.strMale;
            if (name == "strMsgBirthDate")
                return Content.lang.eng.strMsgBirthDate;
            if (name == "strMsgEnterMail")
                return Content.lang.eng.strMsgEnterMail;
            if (name == "strMsgNick")
                return Content.lang.eng.strMsgNick;
            if (name == "strMsgPassword")
                return Content.lang.eng.strMsgPassword;
            if (name == "strMsgSecurityCode")
                return Content.lang.eng.strMsgSecurityCode;
            if (name == "strNameAndSurname")
                return Content.lang.eng.strNameAndSurname;
            if (name == "strNick")
                return Content.lang.eng.strNick;
            if (name == "strPassword")
                return Content.lang.eng.strPassword;
            if (name == "strPoet")
                return Content.lang.eng.strPoet;
            if (name == "strPoetManagement")
                return Content.lang.eng.strPoetManagement;
            if (name == "strPoetries")
                return Content.lang.eng.strPoetries;
            if (name == "strPoetry")
                return Content.lang.eng.strPoetry;
            if (name == "strPoetryManagement")
                return Content.lang.eng.strPoetryManagement;
            if (name == "strPoets")
                return Content.lang.eng.strPoets;
            if (name == "strRememberMe")
                return Content.lang.eng.strRememberMe;
            if (name == "strSearch")
                return Content.lang.eng.strSearch;
            if (name == "strSecurityCode")
                return Content.lang.eng.strSecurityCode;
            if (name == "strSelectLang")
                return Content.lang.eng.strSelectLang;
            if (name == "strUserManagement")
                return Content.lang.eng.strUserManagement;
            return "";
        }

        private static string getUiLangTrTextFor(string name)
        {
            if (name == "strAbout")
                return Content.lang.tr.strAbout;
            if (name == "strAdminPanel")
                return Content.lang.tr.strAdminPanel;
            if (name == "strAlreadyAccount")
                return Content.lang.tr.strAlreadyAccount;
            if (name == "strBirthDate")
                return Content.lang.tr.strBirthDate;
            if (name == "strCategories")
                return Content.lang.tr.strCategories;
            if (name == "strCategory")
                return Content.lang.tr.strCategory;
            if (name == "strCategoryManagement")
                return Content.lang.tr.strCategoryManagement;
            if (name == "strComplete")
                return Content.lang.tr.strComplete;
            if (name == "strConfirm")
                return Content.lang.tr.strConfirm;
            if (name == "strContact")
                return Content.lang.tr.strContact;
            if (name == "strCreateAcc")
                return Content.lang.tr.strCreateAcc;
            if (name == "strCreateAccount")
                return Content.lang.tr.strCreateAccount;
            if (name == "strDeleteUser")
                return Content.lang.tr.strDeleteUser;
            if (name == "strFemale")
                return Content.lang.tr.strFemale;
            if (name == "strGender")
                return Content.lang.tr.strGender;
            if (name == "strHome")
                return Content.lang.tr.strHome;
            if (name == "strInstall")
                return Content.lang.tr.strInstall;
            if (name == "strLangText")
                return Content.lang.tr.strLangText;
            if (name == "strLogin")
                return Content.lang.tr.strLogin;
            if (name == "strLogOut")
                return Content.lang.tr.strLogOut;
            if (name == "strMail")
                return Content.lang.tr.strMail;
            if (name == "strMakeAdmin")
                return Content.lang.tr.strMakeAdmin;
            if (name == "strMakeNormal")
                return Content.lang.tr.strMakeNormal;
            if (name == "strMale")
                return Content.lang.tr.strMale;
            if (name == "strMsgBirthDate")
                return Content.lang.tr.strMsgBirthDate;
            if (name == "strMsgEnterMail")
                return Content.lang.tr.strMsgEnterMail;
            if (name == "strMsgNick")
                return Content.lang.tr.strMsgNick;
            if (name == "strMsgPassword")
                return Content.lang.tr.strMsgPassword;
            if (name == "strMsgSecurityCode")
                return Content.lang.tr.strMsgSecurityCode;
            if (name == "strNameAndSurname")
                return Content.lang.tr.strNameAndSurname;
            if (name == "strNick")
                return Content.lang.tr.strNick;
            if (name == "strPassword")
                return Content.lang.tr.strPassword;
            if (name == "strPoet")
                return Content.lang.tr.strPoet;
            if (name == "strPoetManagement")
                return Content.lang.tr.strPoetManagement;
            if (name == "strPoetries")
                return Content.lang.tr.strPoetries;
            if (name == "strPoetry")
                return Content.lang.tr.strPoetry;
            if (name == "strPoetryManagement")
                return Content.lang.tr.strPoetryManagement;
            if (name == "strPoets")
                return Content.lang.tr.strPoets;
            if (name == "strRememberMe")
                return Content.lang.tr.strRememberMe;
            if (name == "strSearch")
                return Content.lang.tr.strSearch;
            if (name == "strSecurityCode")
                return Content.lang.tr.strSecurityCode;
            if (name == "strSelectLang")
                return Content.lang.tr.strSelectLang;
            if (name == "strUserManagement")
                return Content.lang.tr.strUserManagement;
            return "";
        }

        public static string CreateMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString().ToUpper();

        }
        public static bool MailIsValid(string emailaddress)
        {
            try
            {

                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static IHtmlString ReadyPoetry(string data)
        {
            IHtmlString html = new HtmlString(data);
            return html;



        }
    }
}