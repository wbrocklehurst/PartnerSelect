using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PartnerSelectLib;

namespace PartnerSelect
{
    public partial class UpdateFavourite : System.Web.UI.Page
    {
        private const int BadRequest = 400;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve request parameters
            var id = Request.QueryString["id"];

            // Check for null parameters, and if found, return BadRequest statusCode
            if (string.IsNullOrEmpty(id))
            {
                Response.StatusCode = BadRequest;
                return;
            }

            // Lookup person by employeeNumber
            Person person = StaticCache.FindPersonById(id);
            StaticCache.PersonToFavourites(person);
        }
    }
}