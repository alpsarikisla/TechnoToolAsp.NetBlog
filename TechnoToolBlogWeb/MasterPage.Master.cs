using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uye u = Session["uye"] as Uye;//Unboxing
                pnl_girisvar.Visible = true;
                pnl_girisyok.Visible = false;
                ltrl_uye.Text = u.KullaniciAdi;
            }
            else
            {
                pnl_girisvar.Visible = false;
                pnl_girisyok.Visible = true;
            }

            rp_kategoriler.DataSource = db.TumKategorileriGetir(true);
            rp_kategoriler.DataBind();
        }
    }
}