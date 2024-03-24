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
            rp_kategoriler.DataSource = db.TumKategorileriGetir(true);
            rp_kategoriler.DataBind();
        }
    }
}