using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb.AdminPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        VeriModeli dm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    Kategori kat = dm.KategoriGetir(id);
                    tb_isim.Text = kat.Isim;
                    tb_aciklama.Text = kat.Aciklama;
                    cb_durum.Checked = kat.Durum;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
            Kategori kat = dm.KategoriGetir(id);
            kat.Isim = tb_isim.Text;
            kat.Aciklama = tb_aciklama.Text;
            kat.Durum = cb_durum.Checked;
            if (dm.KategoriDuzenle(kat))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_hatamesaj.Text = "Kategori düzenlenirken bir hata oluştu";
            }
        }
    }
}