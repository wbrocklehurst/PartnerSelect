using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PartnerSelectLib;
using System.Globalization;

namespace PartnerSelect
{
    public partial class Search : System.Web.UI.Page
    {
        private string _firstName;
        private string _surname;
        private string _officeId;
        private string _departmentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetLocalVariables();
            LoadData();
            PerformSearch();                  
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Value = string.Empty;
            txtSurname.Value = string.Empty;
            lstOffices.SelectedIndex = 0;
            lstDepartments.SelectedIndex = 0;
            lstGender.SelectedIndex = 0;
            lstVoting.SelectedIndex = 0;

            rptSearch.DataSource = new List<Person>();
            rptSearch.DataBind();
        }

        protected void rptSearch_ItemDataBound(object sender, RepeaterItemEventArgs e) // NOSONAR
        {
            var item = e.Item;
            if (item.ItemType != ListItemType.AlternatingItem && item.ItemType != ListItemType.Item)
            {
                return;
            }

            var person = (Person)e.Item.DataItem;

            bool inFavouritesList = StaticCache.IsPersonInFavourites(person);
            var lnkFavourite = (HyperLink)item.FindControl("lnkFavouritesIndicator");
            lnkFavourite.NavigateUrl = String.Format("Javascript:UpdateFavourites({0})", person.EmployeeNumber);
            if (inFavouritesList)
            {
                lnkFavourite.CssClass = "fa fa-star";
            }

            var lblGender = (Label)item.FindControl("lblGender");
            lblGender.Text = Enums.StringValueOf(person.Gender);

            var furtherInfoLink = (HyperLink)item.FindControl("lnkFurtherInfo");
            furtherInfoLink.NavigateUrl = String.Format("Javascript:FurtherInfo({0})", person.EmployeeNumber);
        }

        /// <summary>
        /// Store values to variables for reuse, i.e. (setting value in model window)
        /// </summary>
        private void SetLocalVariables()
        {
            _firstName = txtFirstName.Value;
            _surname = txtSurname.Value;
            _officeId = lstOffices.Value;
            _departmentId = lstDepartments.Value;
        }

        /// <summary>
        /// Load all data elements
        /// </summary>
        private void LoadData()
        {
            LoadOffices();
            LoadDpartments();

            // restore previous value
            txtFirstName.Value = _firstName;
            txtSurname.Value = _surname;
        }

        private void LoadDpartments()
        {
            lstDepartments.Items.Clear();
            lstDepartments.Items.Add(new ListItem("All Departments", ""));

            var departments = StaticCache.GetDepartments();
            foreach (var department in departments)
            {
                lstDepartments.Items.Add(new ListItem(department.Name, department.Id.ToString(CultureInfo.InvariantCulture)));
            }

            // select previous value
            if (!string.IsNullOrEmpty(_departmentId))
            {
                lstDepartments.SelectedIndex = lstDepartments.Items.IndexOf(lstDepartments.Items.FindByValue(_departmentId));
            }
        }
                
        private void LoadOffices()
        {
            lstOffices.Items.Clear();
            lstOffices.Items.Add(new ListItem("All Offices", ""));

            var offices = StaticCache.GetOffices();
            foreach (var office in offices)
            {
                lstOffices.Items.Add(new ListItem(office.Name, office.Id.ToString(CultureInfo.InvariantCulture)));
            }

            // select previous value
            if (!string.IsNullOrEmpty(_officeId))
            {
                lstOffices.SelectedIndex = lstOffices.Items.IndexOf(lstOffices.Items.FindByValue(_officeId));
            }
        }

        private void PerformSearch()
        {
            List<Person> searchResults = new List<Person>();
            if (IsPostBack)
            {
                searchResults = GetFilteredData(txtFirstName.Value, txtSurname.Value, lstOffices.Value, lstDepartments.Value, true);
            }

            rptSearch.DataSource = searchResults;
            rptSearch.DataBind();
        }

        public static List<Person> GetFilteredData(string firstName, string lastName, string office, string department, bool active)
        {
            IQueryable<Person> oDataQuery = StaticCache.GetEmployees().AsQueryable();

            if (firstName.Trim().Length > 0)
            {
                oDataQuery = oDataQuery.Where(a => a.FirstName.StartsWith(firstName, true, CultureInfo.InvariantCulture));
            }

            if (lastName.Trim().Length > 0)
            {
                oDataQuery = oDataQuery.Where(a => a.LastName.StartsWith(lastName, true, CultureInfo.InvariantCulture));
            }

            if (office.Trim().Length > 0)
            {
                oDataQuery = oDataQuery.Where(a => a.Office.Id.ToString().Equals(office.ToString()));
            }

            if (department.Trim().Length > 0)
            {
                oDataQuery = oDataQuery.Where(a => a.Department.Id.ToString().Equals(department.ToString()));
            }

            return oDataQuery.ToList();
        }
    }
}