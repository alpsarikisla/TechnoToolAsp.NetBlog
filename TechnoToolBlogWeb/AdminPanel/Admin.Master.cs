using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb.AdminPanel
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] == null)
            {
                Response.Redirect("AdminGiris.aspx");
            }
            else
            {
                Yonetici yon = (Yonetici)Session["yonetici"]; //Unboxing
                lbl_kullanici.Text = yon.KullaniciAdi + "(" + yon.YoneticiTur + ")";
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("AdminGiris.aspx");
        }
    }
}