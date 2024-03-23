using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb.AdminPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = db.TumKategorileriGetir();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                db.KategoriSil(id);
            }
            if (e.CommandName == "durum")
            {
                db.KategoriDurumDegistir(id);
            }

            lv_kategoriler.DataSource = db.TumKategorileriGetir();
            lv_kategoriler.DataBind();
        }
    }
}