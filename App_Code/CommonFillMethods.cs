using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropdownList();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
        }

        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropdownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropdownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        public static void FillDropDownListBloodGroup(DropDownList ddl)
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            ddl.DataSource = balBloodGroup.SelectForDropdownList();
            ddl.DataValueField = "BloodGroupID";
            ddl.DataTextField = "BloodGroupName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Blood Group", "-1"));
        }

        public static void FillDropDownListContactCategory(DropDownList ddl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectForDropdownList();
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
        }

        public static void FillDropDownStateByCountryID(DropDownList ddl, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropdownList(CountryID);
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }

        public static void FillDropDownCityByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropdownList(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        public static void FillDropDownListEmpty(DropDownList ddl, String DropDownListName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select " + DropDownListName, "-1"));
        }
    }
}