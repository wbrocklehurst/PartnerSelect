using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartnerSelect
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterHiddenField("lblFavouritesCountClientID", this.lblFavouritesCount.ClientID);
            SetFavouritesCount();
        }

        private void SetFavouritesCount()
        {
            lblFavouritesCount.InnerText = StaticCache.GetFavourites().Count.ToString();
        }
    }
}
