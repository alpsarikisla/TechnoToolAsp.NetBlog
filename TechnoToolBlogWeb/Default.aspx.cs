using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace TechnoToolBlogWeb
{
    public partial class Default : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.Count == 0)
            {
                rp_makaleler.DataSource = db.MakaleListele(true);
                rp_makaleler.DataBind();
            }
            else
            {
                int katid = Convert.ToInt32(Request.QueryString["kategoriID"]);
                rp_makaleler.DataSource = db.MakaleListele(katid);
                rp_makaleler.DataBind();
            }
        }
    }
}