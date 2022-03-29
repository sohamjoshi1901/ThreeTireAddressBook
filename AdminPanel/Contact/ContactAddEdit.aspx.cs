using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillDropDownListCountry();
            FillDropDownListBloodGroup();
            FillDropDownListContactCategory();

            if (Request.QueryString["ContactID"] != null)
            {

                FillDropDownListState();
                FillDropDownListCity();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
        }
    }
    #endregion Page Load

    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion Button : Cancel

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";
        if (txtPeresonName.Text.Trim() == "")
            strError += "-Enter Person Name</br>";
        if (ddlCountry.SelectedIndex == 0)
            strError += "-Select Country</br>";
        if (ddlState.SelectedIndex == 0)
            strError += "-Select State</br>";
        if (ddlCity.SelectedIndex == 0)
            strError += "-Select City</br>";
        if (ddlBloodGroup.SelectedIndex == 0)
            strError += "-Select Blood Group</br>";

        if (ddlContactCategory.SelectedIndex == 0)
            strError += "-Select Contact Category</br>";
        if (txtMobileNo.Text.Trim() == "")
            strError += "-Enter Mobile Number</br>";


        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect From data

        ContactENT entContact = new ContactENT();
        if (ddlCountry.SelectedIndex > 0)
            entContact.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

        if (ddlState.SelectedIndex > 0)
            entContact.StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (ddlCity.SelectedIndex > 0)
            entContact.CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlBloodGroup.SelectedIndex > 0)
            entContact.BloodGroupID = Convert.ToInt32(ddlBloodGroup.SelectedValue);

        if (ddlContactCategory.SelectedIndex > 0)
            entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);

        if (txtPeresonName.Text.Trim() != "")
            entContact.PersonName = txtPeresonName.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            entContact.Address = txtAddress.Text.Trim();

        if (txtPincode.Text.Trim() != "")
            entContact.PinCode = txtPincode.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            entContact.MobileNo = txtMobileNo.Text.Trim();

        if (txtPhoneNo.Text.Trim() != "")
            entContact.PhoneNo = txtPhoneNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entContact.Email = txtEmail.Text.Trim();

        if (txtGender.Text.Trim() != "")
            entContact.Gender = txtGender.Text.Trim();

        if (txtBirthDate.Text.Trim() != "")
            entContact.Birthdate = Convert.ToDateTime(txtBirthDate.Text.Trim());

        if (txtProfession.Text.Trim() != "")
            entContact.Profession = txtProfession.Text.Trim();

        #endregion Collect From data

        ContactBAL balContact = new ContactBAL();
        if (Request.QueryString["ContactID"] != null)
        {
            #region Update
            entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
            if (balContact.Update(entContact))
            {
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Update
        }
        else
        {
            #region Add
            if (balContact.Insert(entContact))
            {
                lblMessage.Text = "Data Inserted SuccessFully";
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Add
        }
    }
    #endregion Button : Save

    #region Fill DropDownList
    private void FillDropDownListCountry()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
    }
    private void FillDropDownListBloodGroup()
    {
        CommonFillMethods.FillDropDownListBloodGroup(ddlBloodGroup);
    }
    private void FillDropDownListContactCategory()
    {
        CommonFillMethods.FillDropDownListContactCategory(ddlContactCategory);
    }
    #endregion Fill DropDownList

    #region country SelectedIndexChanged
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue.Trim()));

        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlState, "State");


        }
        CommonFillMethods.FillDropDownListEmpty(ddlCity, "City");
    }
    #endregion country SelectedIndexChanged

    #region State SelectedIndexChanged
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue.Trim()));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlCity, "City");

        }
    }
    #endregion country SelectedIndexChanged

    #region FillControls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);

        if (!entContact.PersonName.IsNull)
            txtPeresonName.Text = entContact.PersonName.Value.ToString();

        if (!entContact.Address.IsNull)
            txtAddress.Text = entContact.Address.Value.ToString();

        if (!entContact.PinCode.IsNull)
            txtPincode.Text = entContact.PinCode.Value.ToString();

        if (!entContact.MobileNo.IsNull)
            txtMobileNo.Text = entContact.MobileNo.Value.ToString();

        if (!entContact.PhoneNo.IsNull)
            txtPhoneNo.Text = entContact.PhoneNo.Value.ToString();

        if (!entContact.Email.IsNull)
            txtEmail.Text = entContact.Email.Value.ToString();

        if (!entContact.Gender.IsNull)
            txtGender.Text = entContact.Gender.Value.ToString();

        if (!entContact.Birthdate.IsNull)
            txtBirthDate.Text = entContact.Birthdate.Value.ToString();

        if (!entContact.Profession.IsNull)
            txtProfession.Text = entContact.Profession.Value.ToString();


        if (!entContact.StateID.IsNull)
            ddlState.SelectedValue = entContact.StateID.Value.ToString();

        if (!entContact.CountryID.IsNull)
            ddlCountry.SelectedValue = entContact.CountryID.Value.ToString();

        if (!entContact.CityID.IsNull)
            ddlCity.SelectedValue = entContact.CityID.Value.ToString();

        if (!entContact.BloodGroupID.IsNull)
            ddlBloodGroup.SelectedValue = entContact.BloodGroupID.Value.ToString();

        if (!entContact.ContactCategoryID.IsNull)
            ddlContactCategory.SelectedValue = entContact.ContactCategoryID.Value.ToString();
    }
    #endregion FillControls

    #region FillDropDownListState
    private void FillDropDownListState()
    {
        CommonFillMethods.FillDropDownListState(ddlState);
    }
    #endregion FillDropDownListState

    #region FillDropDownListCity
    private void FillDropDownListCity()
    {
        CommonFillMethods.FillDropDownListCity(ddlCity);
    }
    #endregion FillDropDownListCity
}
