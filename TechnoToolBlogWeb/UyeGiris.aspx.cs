using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            Uye u = db.UyeGiris(tb_mail.Text, tb_sifre.Text);
            if (u.ID != 0)
            {
                Session["uye"] = u;
                Response.Redirect("Default.aspx");
            }
        }
    }
}