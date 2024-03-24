using System;
using System.Collections.Generic;
using System.IO;
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
            int id = Convert.ToInt32(Request.QueryString["makaleID"]);
            Makale mak = db.MakaleGetir(id);
            mak.Durum = cb_durum.Checked;
            mak.Baslik = tb_baslik.Text;
            mak.Ozet = tb_ozet.Text;
            mak.Icerik = tb_Icerik.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            bool eklemedurum = true; 
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string resimuzanti = fi.Extension;
                if (resimuzanti == ".jpg" || resimuzanti == ".png")
                {
                    string isim = Guid.NewGuid().ToString();
                    mak.KapakResim = isim + resimuzanti;
                    fu_resim.SaveAs(Server.MapPath("../Resimler/MakaleResimleri/" + isim + resimuzanti));
                }
                else
                {
                    eklemedurum = false;
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Resim Formatı uygun değildir. jpg ve png dosya kabul edilir";
                }
            }
            if (eklemedurum)
            {
                if (db.MakaleDuzenle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_hatamesaj.Text = "Makale Düzenlenirken Bir Hata Oluştu";
                }
            }
        }
    }
}