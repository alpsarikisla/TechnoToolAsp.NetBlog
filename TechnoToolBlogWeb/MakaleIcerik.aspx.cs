using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb
{
    public partial class MakaleIcerik : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                Makale m = db.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                ltrl_Icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_Tarih.Text = m.TarihStr;
                ltrl_Yazar.Text = m.Yazar;
                img_resim.ImageUrl = "Resimler/MakaleResimleri/" + m.KapakResim;

                //rp_yorumlar.DataSource = db.yorumlariGetir(id);
                //rp_yorumlar.DataBind();

                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisYok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = false;
                    pnl_girisYok.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}