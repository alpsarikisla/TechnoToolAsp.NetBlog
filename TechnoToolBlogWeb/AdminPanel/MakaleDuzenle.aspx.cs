using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb.AdminPanel
{
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["makaleID"]);
                    Makale mak = db.MakaleGetir(id);

                    ddl_kategoriler.DataSource = db.TumKategorileriGetir();
                    ddl_kategoriler.DataBind();
                    ddl_kategoriler.SelectedValue = mak.Kategori_ID.ToString();

                    tb_baslik.Text = mak.Baslik;
                    tb_Icerik.Text = mak.Icerik;
                    tb_ozet.Text = mak.Ozet;
                    cb_durum.Checked = mak.Durum;
                    img_resim.ImageUrl = "../Resimler/MakaleResimleri/" + mak.KapakResim;
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {

        }
    }
}