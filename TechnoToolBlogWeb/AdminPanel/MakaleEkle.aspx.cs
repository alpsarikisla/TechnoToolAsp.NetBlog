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
    public partial class MakaleEkle : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataSource = db.TumKategorileriGetir();
            ddl_kategoriler.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                bool eklemedurum = true;
                Makale mak = new Makale();
                mak.Baslik = tb_baslik.Text;
                mak.Durum = cb_durum.Checked;
                mak.GoruntulemeSayi = 0;
                mak.Icerik = tb_Icerik.Text;
                mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.Ozet = tb_ozet.Text;
                mak.Tarih = DateTime.Now;
                Yonetici y = (Yonetici)Session["yonetici"];
                mak.Yazar_ID = y.ID;
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
                else
                {
                    mak.KapakResim = "none.png";
                }
                if (eklemedurum)
                {
                    if (db.MakaleEkle(mak))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_hatamesaj.Text = "Makale eklenirken bir hata oluştu";
                    }
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Başlık Boş bırakılmamalıdır";
            }
        }
    }
}