using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using PartnerSelectLib;
using Newtonsoft.Json;

namespace PartnerSelect
{
    public partial class Lookup : Page
    {
        [WebMethod]
        public static object GetPersonById(string id)
        {
            try
            {
                List<Person> employees = StaticCache.GetEmployees();
                var filtered = employees.Where(x => x.EmployeeNumber.ToString() == id).ToList();
                return JsonConvert.SerializeObject(filtered, Formatting.Indented);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Error Loading Instance with id {0}, Error: {1}", id, exception));
            }
        }
    }
}