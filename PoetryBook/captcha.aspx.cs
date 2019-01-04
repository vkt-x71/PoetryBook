using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoetryBook
{
    public partial class captcha : System.Web.UI.Page
    {
        public string RandomString(int loop)
        {
            Random rdm = new Random();
            string deger = "";

            for (int i = 0; i < loop; i++)
            {
                deger += ((char)rdm.Next('A', 'Z')).ToString() + ((int)rdm.Next(0, 9)); //her dönmede        rasgele 1 harf 1 rakam üretir.
            }

            return deger;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(100, 50);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Lavender); //captcha'Nin arka plan rengidir.

                string deger = RandomString(3); /*RandomString metodaki döngünün
3 kez tekrarlamasını sağlar. Böylece harf+rakam 6 karakter üretilmesi sağlanır.*/
                Session["resim"] = deger;
                g.DrawString(deger, new Font(FontFamily.Families[11], 15, FontStyle.Bold), //karakterler        yazılır.
                new SolidBrush(Color.Black), 5, 10);

                bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg); //captcha hazırdır ve
            }
            catch (Exception hata)
            {
                Response.Write(hata.Message);
            }
        }
    }
}