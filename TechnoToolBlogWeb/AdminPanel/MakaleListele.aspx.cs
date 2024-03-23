using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb.AdminPanel
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = db.MakaleListele();
            lv_makaleler.DataBind();
        }
    }
}