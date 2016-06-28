using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PartnerSelectLib;

namespace PartnerSelect
{
    public partial class Favourites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var favouritesList = StaticCache.GetFavourites();

            rptFavourites.DataSource = favouritesList;
            rptFavourites.DataBind();

            if (favouritesList.Count > 0)
            {
                noneSelected.Visible = false;
            }
        }

        protected void rptFavourites_ItemDataBound(object sender, RepeaterItemEventArgs e) // NOSONAR
        {
            var item = e.Item;
            if (item.ItemType != ListItemType.AlternatingItem && item.ItemType != ListItemType.Item)
            {
                return;
            }

            var person = (Person)e.Item.DataItem;

            //var lblGender = (Label)item.FindControl("lblGender");
            //lblGender.Text = Enums.StringValueOf(person.Gender);

            //var furtherInfoLink = (HyperLink)item.FindControl("lnkFurtherInfo");
            //furtherInfoLink.NavigateUrl = String.Format("Javascript:FurtherInfo({0})", person.EmployeeNumber);
        }        
    }
}